
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.Interface
{
    public interface ISubDetailHeadRepo : IRepository<SubDetailHead>
    {
        public Task<ICollection<SubDetailHead>> GetAllSubDetailHeads();
        
    }
}
