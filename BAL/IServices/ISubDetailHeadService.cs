using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface ISubDetailHeadService
    {
        Task<IEnumerable<SubDetailHeadModel>> getAllSubDetail();
        Task<SubDetailHeadModel> GetSubDetailHead(int Id);
        Task<SubDetailHeadModel> CreateSubDetail(SubDetailHeadModel SubDe);
        Task<bool> DeleteSubDetail(int Id);
        Task<bool> UpdateSubDetail(int Id, SubDetailHeadModel SubDe);
    }
}
