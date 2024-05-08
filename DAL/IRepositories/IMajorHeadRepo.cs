using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.IRepositories
{
    public interface IMajorHeadRepo : IRepository<MajorHead>
    {
        public Task<ICollection<MajorHead>> GetAllMajorHeads();


    }
}
