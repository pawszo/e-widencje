using e_widencje.Contexts;
using e_widencje.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace e_widencje.Repositories
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
