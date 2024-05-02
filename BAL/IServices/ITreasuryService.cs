using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.IServices
{
    public interface ITreasuryService
    {
        Task<IEnumerable<TreasuryModel>> getAllDetail();
        Task<TreasuryModel> CreateTreasury(TreasuryModel treasuryData);
        Task<bool> DeleteTreasury(int Id);
        Task<bool> UpdateTreasury(int Id, TreasuryModel treasuryData);
        Task<TreasuryModel> GetTreasuryDetail(int id);

    }
}
