using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.Repository
{
    public class DetailHeadRepo : Repository<DetailHead, IfmsContext>, IDetailHeadRepo
    {
        public DetailHeadRepo(IfmsContext context) : base(context)
        {
        }

        
       public async Task<ICollection<DetailHead>> GetAllDetailHeads()
        {
            IQueryable<DetailHead> result = this.IfmsContext.Set<DetailHead>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }
       

    }
}
