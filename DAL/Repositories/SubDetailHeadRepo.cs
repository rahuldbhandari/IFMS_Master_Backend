using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class SubDetailHeadRepo : Repository<SubDetailHead, ifmsContext>, ISubDetailHeadRepo
    {
        public SubDetailHeadRepo(ifmsContext context) : base(context)
        {
        }
        public async Task<ICollection<SubDetailHead>> GetAllSubDetailHeads()
        {
            IQueryable<SubDetailHead> result = this.ifmsContext.Set<SubDetailHead>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }

    }
}
