using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.DAL.Entities;

using IFMS_Master_Backend.DAL;

using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class MinorHeadService : IMinorHeadService
    {
        private readonly IMinorHeadRepo _MinorHeadRepo;
        private readonly IMapper _mapper;
        public MinorHeadService(IMinorHeadRepo MinorHeadRepo, IMapper mapper)
        {
            _MinorHeadRepo = MinorHeadRepo;
            _mapper = mapper;
        }
        public async Task<ICollection<MinorHeadModel>> getAllMinorHead()
        {
            ICollection<MinorHead> allHeadData = await _MinorHeadRepo.GetAllMinorHeads();
            return _mapper.Map<List<MinorHeadModel>>(allHeadData);
        }

        public async Task<MinorHeadModel> GetMinorHeadById(int Id)
        {
            MinorHead minorHeads = await _MinorHeadRepo.GetSingleAysnc(head => head.Id == Id && head.IsDeleted == false);
            //_MajorHeadRepo.GetAllByCondition(a => a.IsDeleted == false);


            return _mapper.Map<MinorHeadModel>(minorHeads);
        }

        public async Task<MinorHeadModel> CreateMinorHead(MinorHeadModel hed)
        {
            MinorHead? minorHead = _mapper.Map<MinorHead>(hed);
            if (_MinorHeadRepo.Add(minorHead))
            {
                _MinorHeadRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<MinorHeadModel>(minorHead);
        }



        public async Task<bool> DeleteMinorHead(int Id)
        {
            MinorHead minorHeadToDelete = await _MinorHeadRepo.GetSingleAysnc(mhead => mhead.Id == Id);
            if (minorHeadToDelete == null)
            {
                // Head not found
                return false;
            }
            minorHeadToDelete.IsDeleted = true;
            var result = _MinorHeadRepo.Update(minorHeadToDelete);
            _MinorHeadRepo.SaveChangesManaged();
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

        public async Task<bool> UpdateMinorHead(int Id, MinorHeadModel mheadData)
        {
            MinorHead minorHeadToUpdate = await _MinorHeadRepo.GetSingleAysnc(mhead => mhead.Id == Id);
            if (minorHeadToUpdate == null)
            {
                // Head not found
                return false;
            }
            //minorHeadToUpdate.Id = (short)mheadData.Id;
            minorHeadToUpdate.Name = mheadData.Name;
            minorHeadToUpdate.Code = mheadData.Code;
            minorHeadToUpdate.SubMajorId = mheadData.SubMajorId;
            var result = _MinorHeadRepo.Update(minorHeadToUpdate);
            _MinorHeadRepo.SaveChangesManaged();
            return true;
        }


    }
}
