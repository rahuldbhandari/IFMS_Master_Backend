using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class DdoService : IDdoService
    {
        private readonly IDdoRepo _DdoRepo;
        private readonly IMapper _mapper;
        public DdoService(IDdoRepo DdoRepo, IMapper mapper)
        {
            _DdoRepo = DdoRepo;
            _mapper = mapper;
        }
        public async Task<ICollection<DdoModel>> getAllDetail()
        {
            List<Ddo> allDdoData = (List<Ddo>)await _DdoRepo.GetAllDdoDetail();
            return _mapper.Map<List<DdoModel>>(allDdoData);
        }

        public async Task<DdoModel> CreateDdo(DdoModel dr)
        {
            Ddo? ddo = _mapper.Map<Ddo>(dr);

            if (_DdoRepo.Add(ddo))
            {
                _DdoRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<DdoModel>(ddo);
        }
        public async Task<bool> DeleteDdo(int Id)
        {
            //var userToDelete = await _UserRepo.GetUserById(userId);
            Ddo ddoToDelete = await _DdoRepo.GetSingleAysnc(ddo => ddo.Id == Id);

            if (ddoToDelete == null)
            {
                // User not found
                return false;
            }
            ddoToDelete.IsDeleted = true;
            var result = _DdoRepo.Update(ddoToDelete);
            _DdoRepo.SaveChangesManaged();
            return true;


        }
        public async Task<DdoModel> GetDdoDetail(int Id)
        {
            Ddo ddo = await _DdoRepo.GetSingleAysnc(ddo => ddo.Id == Id && ddo.IsDeleted == false);


            return _mapper.Map<DdoModel>(ddo);
        }



        public async Task<bool> UpdateDdo(int Id, DdoModel ddoData)
        {
            Ddo ddoToUpdate = await _DdoRepo.GetSingleAysnc(ddo => ddo.Id == Id);
            if (ddoToUpdate == null)
            {
                // User not found
                return false;
            }
            ddoToUpdate.TreasuryCode = ddoToUpdate.TreasuryCode;
            ddoToUpdate.TreasuryMstId = ddoToUpdate.TreasuryMstId;
            ddoToUpdate.Code = ddoToUpdate.Code;
            ddoToUpdate.Designation = ddoToUpdate.Designation;
            ddoToUpdate.DesignationMstId = ddoToUpdate.DesignationMstId;
            ddoToUpdate.Address = ddoToUpdate.Address;
            ddoToUpdate.Phone = ddoToUpdate.Phone;

            var result = _DdoRepo.Update(ddoToUpdate);
            _DdoRepo.SaveChangesManaged();
            return true;
        }


    }
}
