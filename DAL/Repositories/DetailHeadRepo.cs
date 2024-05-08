using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class DetailHeadRepo : Repository<DetailHead, ifmsContext>, IDetailHeadRepo
    {
        public DetailHeadRepo(ifmsContext context) : base(context)
        {
        }


        public async Task<ICollection<DetailHead>> GetAllDetailHeads()
        {
            IQueryable<DetailHead> result = this.ifmsContext.Set<DetailHead>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }


    }
}
