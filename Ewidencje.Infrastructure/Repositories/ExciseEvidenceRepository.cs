using Ewidencje.Domain.Models;
using Ewidencje.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;

namespace Ewidencje.Infrastructure.Repositories
{
    public class ExciseEvidenceRepository : RepositoryBase<ExciseEvidence, MainDbContext>
    {
        public ExciseEvidenceRepository(MainDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public override Task<ExciseEvidence> Delete(int id) => null;

        public override async Task<ExciseEvidence> Update(int id, ExciseEvidence evidenceUpdate)
        {
            var currentEvidence = await Get(id);
            if (currentEvidence is null)
                return null;

            ApplyUpdates(currentEvidence, evidenceUpdate);
            var newEvidenceVersion = await Add(currentEvidence);

            if (newEvidenceVersion == null)
                return null;

            return newEvidenceVersion;

        }
    }
}
