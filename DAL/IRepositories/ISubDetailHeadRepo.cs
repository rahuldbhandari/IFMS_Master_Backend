using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface ISubDetailHeadRepo : IRepository<SubDetailHead>
    {
        public Task<ICollection<SubDetailHead>> GetAllSubDetailHeads();

    }
}
