using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL.Interfaces
{
    public interface IMajorHeadRepo : IRepository<MajorHead>
    {
        public Task<ICollection<MajorHead>> GetAllMajorHeads();


    }
}
