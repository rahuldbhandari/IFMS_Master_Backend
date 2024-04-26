using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.Repository
{
    public class DetailHeadRepo : Repository<Detailhead, IfmsContext>, IDetailHeadRepo
    {
        public DetailHeadRepo(IfmsContext context) : base(context)
        {
        }

        
       public async Task<ICollection<Detailhead>> GetAllDetailHeads()
        {
            IQueryable<Detailhead> result = this.IfmsContext.Set<Detailhead>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }
       

    }
}
