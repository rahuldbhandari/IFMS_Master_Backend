using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface ISubMajorHeadService
    {
        Task<ICollection<SubMajorHeadModel>> getAllSubHead();
        Task<SubMajorHeadModel> getSubHeadById(int Id);
        Task<SubMajorHeadModel> CreateSubHead(SubMajorHeadModel hed);
        Task<bool> DeleteSubHead(int Id);
        Task<bool> UpdateSubHead(int Id, SubMajorHeadModel headData);
    }
}
