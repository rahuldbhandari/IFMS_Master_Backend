using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface ITreasuryRepo : IRepository<Treasury>

    {
        public Task<ICollection<Treasury>> GetAllTreasuryDetail();
    }
}
