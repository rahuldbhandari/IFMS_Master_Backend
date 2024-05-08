using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface IMajorHeadService
    {
        Task<ICollection<MajorHeadModel>> getAllHead();
        Task<MajorHeadModel> CreateHead(MajorHeadModel hed);
        Task<MajorHeadModel> GetHeadById(int Id);
        Task<MajorHeadModel> GetHeadByCode(string Code);
        Task<bool> DeleteHead(int Id);
        Task<bool> UpdateHead(int Id, MajorHeadModel headData);
    }
}
