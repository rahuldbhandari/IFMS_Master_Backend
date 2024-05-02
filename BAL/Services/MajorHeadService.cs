using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;

using IFMS_Master_Backend.DAL;

using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class MajorHeadService : IMajorHeadService
    {
        private readonly IMajorHeadRepo _MajorHeadRepo;
        private readonly IMapper _mapper;
        public MajorHeadService(IMajorHeadRepo HeadRepo, IMapper mapper)
        {
            _MajorHeadRepo = HeadRepo;
            _mapper = mapper;
        }



        public async Task<ICollection<MajorHeadModel>> getAllHead()
        {
            ICollection<MajorHead> allHeadData = await _MajorHeadRepo.GetAllMajorHeads();
            return _mapper.Map<List<MajorHeadModel>>(allHeadData);
        }


        public async Task<MajorHeadModel> GetHeadById(int Id)
        {
            MajorHead majorHeads = await _MajorHeadRepo.GetSingleAysnc(head => head.Id == Id && head.IsDeleted == false);
            //_MajorHeadRepo.GetAllByCondition(a => a.IsDeleted == false);


            return _mapper.Map<MajorHeadModel>(majorHeads);
        }
        public async Task<MajorHeadModel> GetHeadByCode(string Code)
        {
            MajorHead majorHeads = await _MajorHeadRepo.GetSingleAysnc(head => head.Code == Code && head.IsDeleted == false);
            //_MajorHeadRepo.GetAllByCondition(a => a.IsDeleted == false);


            return _mapper.Map<MajorHeadModel>(majorHeads);
        }

        public async Task<MajorHeadModel> CreateHead(MajorHeadModel hed)
        {
            MajorHead? head = _mapper.Map<MajorHead>(hed);
            if (_MajorHeadRepo.Add(head))
            {
                _MajorHeadRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<MajorHeadModel>(head);
        }



        public async Task<bool> DeleteHead(int Id)
        {
            MajorHead headToDelete = await _MajorHeadRepo.GetSingleAysnc(head => head.Id == Id);
            if (headToDelete == null)
            {
                // Head not found
                return false;
            }
            headToDelete.IsDeleted = true;
            var result = _MajorHeadRepo.Update(headToDelete);
            _MajorHeadRepo.SaveChangesManaged();
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

        public async Task<bool> UpdateHead(int Id, MajorHeadModel headData)
        {
            MajorHead headToUpdate = await _MajorHeadRepo.GetSingleAysnc(head => head.Id == Id);
            if (headToUpdate == null)
            {
                // Head not found
                return false;
            }
            //headToUpdate.Id = (short)headData.Id;
            headToUpdate.Name = headData.Name;
            headToUpdate.Code = headData.Code;
            var result = _MajorHeadRepo.Update(headToUpdate);
            _MajorHeadRepo.SaveChangesManaged();
            return true;
        }
    }
}
