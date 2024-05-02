using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;

using IFMS_Master_Backend.DAL;

using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;
namespace IFMS_Master_Backend.BAL.Services
{
    public class SubMajorHeadService : ISubMajorHeadService
    {
        private readonly ISubMajorHeadRepo _SubMajorHeadRepo;
        private readonly IMapper _mapper;
        public SubMajorHeadService(ISubMajorHeadRepo SubMajorHeadRepo, IMapper mapper)
        {
            _SubMajorHeadRepo = SubMajorHeadRepo;
            _mapper = mapper;
        }
        public async Task<ICollection<SubMajorHeadModel>> getAllSubHead()
        {
            ICollection<SubMajorHead> allsubHeadData = await _SubMajorHeadRepo.GetAllSubMajorHeads();
            return _mapper.Map<List<SubMajorHeadModel>>(allsubHeadData);
        }

        public async Task<SubMajorHeadModel> getSubHeadById(int Id)
        {
            SubMajorHead subMajorHeads = await _SubMajorHeadRepo.GetSingleAysnc(head => head.Id == Id && head.IsDeleted == false);
            return _mapper.Map<SubMajorHeadModel>(subMajorHeads);
        }


        public async Task<SubMajorHeadModel> CreateSubHead(SubMajorHeadModel subhed)
        {
            SubMajorHead? subhead = _mapper.Map<SubMajorHead>(subhed);
            if (_SubMajorHeadRepo.Add(subhead))
            {
                _SubMajorHeadRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<SubMajorHeadModel>(subhead);
        }



        public async Task<bool> DeleteSubHead(int Id)
        {
            SubMajorHead subHeadToDelete = await _SubMajorHeadRepo.GetSingleAysnc(head => head.Id == Id);
            if (subHeadToDelete == null)
            {
                // Head not found
                return false;
            }
            subHeadToDelete.IsDeleted = true;
            var result = _SubMajorHeadRepo.Update(subHeadToDelete);
            _SubMajorHeadRepo.SaveChangesManaged();
            return true;
            /*//var headToDelete = await _HeadRepo.GetHeadById(Id);
            MajorHead headToDelete = await _HeadRepo.GetSingleAysnc(head => head.Id == Id);

            if (headToDelete == null)
            {
                // Head not found
                return false;
            }

            var deletionResult = _HeadRepo.Delete(headToDelete);
            _HeadRepo.SaveChangesManaged();

            // Handle the result of the deletion operation
            return deletionResult;*/
        }

        public async Task<bool> UpdateSubHead(int Id, SubMajorHeadModel subHeadData)
        {
            SubMajorHead subHeadToUpdate = await _SubMajorHeadRepo.GetSingleAysnc(shead => shead.Id == Id);
            if (subHeadToUpdate == null)
            {
                // Head not found
                return false;
            }
            //subHeadToUpdate.Id = subHeadData.Id;
            subHeadToUpdate.Name = subHeadData.Name;
            subHeadToUpdate.Code = subHeadData.Code;
            subHeadToUpdate.MajorHeadId = subHeadData.MajorHeadId;
            var result = _SubMajorHeadRepo.Update(subHeadToUpdate);
            _SubMajorHeadRepo.SaveChangesManaged();
            return true;
        }

    }
}
