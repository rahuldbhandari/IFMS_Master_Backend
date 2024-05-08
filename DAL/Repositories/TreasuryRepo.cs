using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class TreasuryRepo:Repository<Treasury, ifmsContext> , ITreasuryRepo
     {
   public TreasuryRepo(ifmsContext context) : base(context)
    {
    }

        public async Task<ICollection<Treasury>> GetAllTreasuryDetail()
        {
            IQueryable<Treasury> result = this.ifmsContext.Set<Treasury>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }
    }

}
