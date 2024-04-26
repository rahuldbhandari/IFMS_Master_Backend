using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface IDetailHeadRepo : IRepository<DetailHead>
    {
        public Task<ICollection<DetailHead>> GetAllDetailHeads();
    }
}
