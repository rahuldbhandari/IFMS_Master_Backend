using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interfaces;
using IFMS_Master_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class TreasuryRepo : Repository<Treasury, IfmsDBContext> , ITreasuryRepo
     {
        public TreasuryRepo(IfmsDBContext context) : base(context)
        {
        }

        public async Task<ICollection<Treasury>> GetTreasuryDetail()
        {
            IQueryable<Treasury> result = this.IfmsDbContext.Set<Treasury>().Where(d => d.IsDelete == false);
            return await result.ToListAsync();
        }
        
    }
}
