using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class SubDetailHeadService : ISubDetailHeadService
    {
        private readonly ISubDetailHeadRepo _SubDetailHeadRepo;
        private readonly IMapper _mapper;
        public SubDetailHeadService(ISubDetailHeadRepo SubDetailHeadRepo, IMapper mapper)
        {
            _SubDetailHeadRepo = SubDetailHeadRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SubDetailHeadModel>> getAllSubDetail()
        {
            List<SubDetailHead> allSubDetailheadData = (List<SubDetailHead>)await _SubDetailHeadRepo.GetAllSubDetailHeads();
            return _mapper.Map<List<SubDetailHeadModel>>(allSubDetailheadData);
        }

        public async Task<SubDetailHeadModel> GetSubDetailHead(int Id)
        {
            SubDetailHead subdetail = await _SubDetailHeadRepo.GetSingleAysnc(delt => delt.Id == Id && delt.IsDeleted == false);
            if (subdetail == null)
            {
                return null;
            }
            return _mapper.Map<SubDetailHeadModel>(subdetail);
        }

        public async Task<SubDetailHeadModel> GetHeadByCode(string Code)
        {
            SubDetailHead subdetail = await _SubDetailHeadRepo.GetSingleAysnc(delt => delt.Code == Code && delt.IsDeleted == false);
            if (subdetail == null)
            {
                return null;
            }
            return _mapper.Map<SubDetailHeadModel>(subdetail);
        }

        public async Task<SubDetailHeadModel> CreateSubDetail(SubDetailHeadModel SubDe)
        {
            SubDetailHead? subdetailhead = _mapper.Map<SubDetailHead>(SubDe);

            if (_SubDetailHeadRepo.Add(subdetailhead))
            {
                _SubDetailHeadRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<SubDetailHeadModel>(subdetailhead);
        }



        public async Task<bool> DeleteSubDetail(int Id)
        {
            //var userToDelete = await _UserRepo.GetUserById(userId);
            SubDetailHead SubDetailHeadToDelete = await _SubDetailHeadRepo.GetSingleAysnc(Delt => Delt.Id == Id);

            if (SubDetailHeadToDelete == null)
            {
                // User not found
                return false;
            }

            SubDetailHeadToDelete.IsDeleted = true;
            var result = _SubDetailHeadRepo.Update(SubDetailHeadToDelete);
            _SubDetailHeadRepo.SaveChangesManaged();
            return true;
        }

        public async Task<bool> UpdateSubDetail(int Id, SubDetailHeadModel Detl)
        {
            SubDetailHead SubDetailHeadToUpdate = await _SubDetailHeadRepo.GetSingleAysnc(Delt => Delt.Id == Id);
            if (SubDetailHeadToUpdate == null)
            {
                // User not found
                return false;
            }
            SubDetailHeadToUpdate.Name = Detl.Name;
            SubDetailHeadToUpdate.Code = Detl.Code;
            SubDetailHeadToUpdate.DetailHeadId = Detl.DetailHeadId;
            var result = _SubDetailHeadRepo.Update(SubDetailHeadToUpdate);
            _SubDetailHeadRepo.SaveChangesManaged();
            return true;
        }

        
    }
}
