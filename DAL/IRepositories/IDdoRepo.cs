using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface IDdoRepo : IRepository<Ddo>
    {
        public Task<ICollection<Ddo>> GetAllDdoDetail();
    }
}
