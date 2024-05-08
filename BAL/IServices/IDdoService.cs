using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface IDdoService
    {
        Task<ICollection<DdoModel>> getAllDetail();
        Task<DdoModel> CreateDdo(DdoModel ddoData);
        Task<bool> DeleteDdo(int Id);
        Task<bool> UpdateDdo(int Id, DdoModel ddoData);
        Task<DdoModel> GetDdoDetail(int id);
    }
}
