using e_widencje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace e_widencje.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryBase(TContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            entity.LastUpdate = System.DateTime.Now;
            entity.LastEditorId = GetLoggedUserId();

            var entityEntry = await _context.Set<TEntity>().AddAsync(entity);
            if (entityEntry.State != EntityState.Added)
                return null;

            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            var removedEntity = _context.Set<TEntity>().Remove(entity);
            if (removedEntity.State != EntityState.Deleted)
                return null;

            await _context.SaveChangesAsync();

            return removedEntity.Entity;
        }

        public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> Update(int id, TEntity entityUpdate)
        {
            var currentEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
            if (currentEntity == null)
                return null;

            ApplyUpdates(currentEntity, entityUpdate);
            currentEntity.LastUpdate = System.DateTime.Now;
            currentEntity.LastEditorId = GetLoggedUserId();

            var updatedEntity = _context.Update(currentEntity);
            if (updatedEntity.State != EntityState.Modified)
                return null;

            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        protected void ApplyUpdates(TEntity currentEntity, TEntity entityUpdate)
        {
            var props = entityUpdate
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !p.Name.Equals("Id") || !p.Name.Equals("LastUpdate") || !p.Name.Equals("LastEditorId"))
                .ToList();

            foreach (var prop in props)
            {
                var updatePropValue = prop.GetValue(entityUpdate);
                if (updatePropValue == null)
                    continue;

                prop.SetValue(currentEntity, updatePropValue);
            }
        }

        protected int GetLoggedUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
