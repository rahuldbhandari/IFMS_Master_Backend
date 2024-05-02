using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface IDetailHeadService
    {
        Task<IEnumerable<DetailHeadModel>> getAllDetail();
        Task<DetailHeadModel> GetDetailHead(int Id);
        Task<DetailHeadModel> CreateDetail(DetailHeadModel Detl);
        Task<bool> DeleteDetail(int Id);
        Task<bool> UpdateDetail(int Id, DetailHeadModel Detl);

    }
}
