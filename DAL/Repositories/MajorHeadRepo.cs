using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class MajorHeadRepo : Repository<MajorHead, ifmsContext>, IMajorHeadRepo
    {
        public MajorHeadRepo(ifmsContext context) : base(context)
        {
        }
        public async Task<ICollection<MajorHead>> GetAllMajorHeads()
        {
            IQueryable<MajorHead> result = this.ifmsContext.Set<MajorHead>().Where(m => m.IsDeleted == false);
            return await result.ToListAsync();
        }

    }
}
