using IFMS_Master_Backend.DAL.Entities;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface ISubMajorHeadRepo : IRepository<SubMajorHead>
    {
        public Task<ICollection<SubMajorHead>> GetAllSubMajorHeads();
        
    }

}
