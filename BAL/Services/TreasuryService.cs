using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class TreasuryService : ITreasuryService
    {
        private readonly ITreasuryRepo _TresuryRepo;
        private readonly IMapper _mapper;
        public TreasuryService(ITreasuryRepo TresuryRepo, IMapper mapper)
        {
            _TresuryRepo = TresuryRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TreasuryModel>> getAllDetail()
        {
            List<Treasury> allTreasuryData = (List<Treasury>)await _TresuryRepo.GetAllTreasuryDetail();
            return _mapper.Map<List<TreasuryModel>>(allTreasuryData);
        }

        public async Task<TreasuryModel> CreateTreasury(TreasuryModel tr)
        {
            Treasury? treasury = _mapper.Map<Treasury>(tr);

            if (_TresuryRepo.Add(treasury))
            {
                _TresuryRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<TreasuryModel>(treasury);
        }
        public async Task<bool> DeleteTreasury(int Id)
        {
            //var userToDelete = await _UserRepo.GetUserById(userId);
            Treasury treasuryToDelete = await _TresuryRepo.GetSingleAysnc(treasury => treasury.Id == Id);

            if (treasuryToDelete == null)
            {
                // User not found
                return false;
            }
            treasuryToDelete.IsDeleted = true;
            var result = _TresuryRepo.Update(treasuryToDelete);
            _TresuryRepo.SaveChangesManaged();
            return true;


        }
        public async Task<TreasuryModel> GetTreasuryDetail(int Id)
        {
            Treasury treasury = await _TresuryRepo.GetSingleAysnc(treasury => treasury.Id == Id && treasury.IsDeleted == false);


            return _mapper.Map<TreasuryModel>(treasury);
        }



        public async Task<bool> UpdateTreasury(int Id, TreasuryModel treasuryData)
        {
            Treasury treasuryToUpdate = await _TresuryRepo.GetSingleAysnc(treasury => treasury.Id == Id);
            if (treasuryToUpdate == null)
            {
                // User not found
                return false;
            }
            treasuryToUpdate.DistrictName = treasuryData.DistrictName;
            treasuryToUpdate.DistrictCode = treasuryData.DistrictCode;
            treasuryToUpdate.Code = treasuryData.Code;
            treasuryToUpdate.Name = treasuryData.Name;

            var result = _TresuryRepo.Update(treasuryToUpdate);
            _TresuryRepo.SaveChangesManaged();
            return true;
        }


    }
}
