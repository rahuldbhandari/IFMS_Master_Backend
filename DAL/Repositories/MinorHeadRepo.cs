using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class MinorHeadRepo : Repository<MinorHead, ifmsContext>, IMinorHeadRepo
    {
        public MinorHeadRepo(ifmsContext context) : base(context)
        {
        }
        public async Task<ICollection<MinorHead>> GetAllMinorHeads()
        {
            IQueryable<MinorHead> result = this.ifmsContext.Set<MinorHead>().Where(md => md.IsDeleted == false);
            return await result.ToListAsync();
        }
    }
}
