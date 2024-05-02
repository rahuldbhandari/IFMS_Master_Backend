using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class DdoRepo : Repository<Ddo, IfmsDBContext>, IDdoRepo
    {
        public DdoRepo(IfmsDBContext context) : base(context)
        {

        }
        public async Task<ICollection<Ddo>> GetDdoDetail()
        {
            IQueryable<Ddo> result = this.IfmsDbContext.Set<Ddo>().Where(d => d.IsDelete == false);
            return await result.ToListAsync();
        }
    }
}
