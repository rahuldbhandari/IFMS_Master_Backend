using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface ISubMajorHeadRepo : IRepository<SubMajorHead>
    {
        public Task<ICollection<SubMajorHead>> GetAllSubMajorHeads();

    }
}
