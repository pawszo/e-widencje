using e_widencje.Contexts;
using e_widencje.Models;
using System.Threading.Tasks;

namespace e_widencje.Repositories
{
    public class ExciseEvidenceRepository : RepositoryBase<ExciseEvidence, MainDbContext>
    {
        public ExciseEvidenceRepository(MainDbContext context) : base(context)
        {
        }

        public override Task<ExciseEvidence> Delete(int id) => null;

        public override async Task<ExciseEvidence> Update(ExciseEvidence evidenceUpdate)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
