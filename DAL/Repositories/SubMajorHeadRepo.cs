using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class SubMajorHeadRepo : Repository<SubMajorHead, ifmsContext>, ISubMajorHeadRepo
    {
        public SubMajorHeadRepo(ifmsContext context) : base(context)
        {

        }
        public async Task<ICollection<SubMajorHead>> GetAllSubMajorHeads()
        {
            IQueryable<SubMajorHead> result = this.ifmsContext.Set<SubMajorHead>().Where(s => s.IsDeleted == false);
            return await result.ToListAsync();
        }

    }
}
