using IFMS_Master_Backend.DAL.Interface;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.Repository
{
    public class SubHeadRepo : Repository<SubDetailHead, IfmsContext>, ISubDetailHeadRepo
    {
        public SubHeadRepo(IfmsContext context) : base(context)
        {
        }
       public async Task<ICollection<SubDetailHead>> GetAllSubDetailHeads()
        {
            IQueryable<SubDetailHead> result = this.IfmsContext.Set<SubDetailHead>().Where(d => d.IsDeleted == false);
            return await result.ToListAsync();
        }

      

       
    }
}
