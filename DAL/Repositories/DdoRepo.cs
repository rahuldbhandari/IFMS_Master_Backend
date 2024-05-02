using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public class DdoRepo : Repository<Ddo, ifmsContext>, IDdoRepo
    {
        public DdoRepo(ifmsContext context) : base(context)
        {

        }
        public async Task<ICollection<Ddo>> GetAllDdoDetail()
        {
            IQueryable<Ddo> result = this.ifmsContext.Set<Ddo>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }
    }
}
