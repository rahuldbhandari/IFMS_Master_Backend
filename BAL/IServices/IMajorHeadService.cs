using IFMS_Master_Backend.DAL;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface IMajorHeadService
    {
        Task<ICollection<MajorHeadModel>> getAllHead();
        Task<MajorHeadModel> CreateHead(MajorHeadModel hed);
        Task<MajorHeadModel> GetHeadById(int Id);
        Task<bool> DeleteHead(int Id);
        Task<bool> UpdateHead(int Id, MajorHeadModel headData);
    }
}
