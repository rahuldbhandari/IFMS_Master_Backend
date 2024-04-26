using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface IMinorHeadRepo : IRepository<MinorHead>
    {
        public Task<ICollection<MinorHead>> GetAllMinorHeads();
    }

}
