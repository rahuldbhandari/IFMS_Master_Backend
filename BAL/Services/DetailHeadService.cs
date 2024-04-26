using AutoMapper;
using IFMS_Master_Backend.BAL.Interfaces;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.Interface;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.BAL.Services
{
    public class DetailHeadService : IDetailHeadService
    {
        private readonly IDetailHeadRepo _DetailHeadRepo;
        private readonly IMapper _mapper;
        public DetailHeadService(IDetailHeadRepo DetailHeadRepo, IMapper mapper)
        {
            _DetailHeadRepo = DetailHeadRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DetailHeadModel>> getAllDetail()
        {
            List<Detailhead> allDetailheadData = (List<Detailhead>)await _DetailHeadRepo.GetAllDetailHeads();
            return _mapper.Map<List<DetailHeadModel>>(allDetailheadData);
        }
        public async Task<DetailHeadModel> CreateDetail(DetailHeadModel Detl)
        {
            Detailhead? detailhead = _mapper.Map<Detailhead>(Detl);

            if (_DetailHeadRepo.Add(detailhead))
            {
                _DetailHeadRepo.SaveChangesManaged(); // Assuming SaveChangesManaged is an asynchronous operation

            }

            return _mapper.Map<DetailHeadModel>(detailhead);
        }
        public async Task<DetailHeadModel> GetDetailHead(int Id)
        {
            Detailhead detailhead = await _DetailHeadRepo.GetSingleAysnc(delt => delt.Id == Id && delt.IsDeleted == false) ;
           

            return _mapper.Map<DetailHeadModel>(detailhead);

        }



        public async Task<bool> DeleteDetail(int Id)
        {
            //var userToDelete = await _UserRepo.GetUserById(userId);
            Detailhead DetailHeadToDelete = await _DetailHeadRepo.GetSingleAysnc(Delt => Delt.Id == Id);

            if (DetailHeadToDelete == null)
            {
                // User not found
                return false;
            }

            DetailHeadToDelete.IsDeleted = true;
            var result = _DetailHeadRepo.Update(DetailHeadToDelete);
            _DetailHeadRepo.SaveChangesManaged();
            return true;
        }

        public async Task<bool> UpdateDetail(int Id, DetailHeadModel Detl)
        {
            Detailhead DetailHeadToUpdate = await _DetailHeadRepo.GetSingleAysnc(Delt => Delt.Id == Id);
            if (DetailHeadToUpdate == null)
            {
                // User not found
                return false;
            }
            DetailHeadToUpdate.Name = Detl.Name;
            DetailHeadToUpdate.Code = Detl.Code;
            var result = _DetailHeadRepo.Update(DetailHeadToUpdate);
            _DetailHeadRepo.SaveChangesManaged();
            return true;
        }

      
    }
}

