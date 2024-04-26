using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using System.Linq.Expressions;

namespace IFMS_Master_Backend.DAL.Interface
{
    public interface IDetailHeadRepo : IRepository<Detailhead>
    {
        public Task<ICollection<Detailhead>> GetAllDetailHeads();
        


    }
}
