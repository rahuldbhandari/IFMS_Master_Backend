using AutoMapper;

using IFMS_Master_Backend.Models;
using IFMS_Master_Backend.DAL.Entities;

namespace Detailhead.Helper
{
    public class MapperClass : Profile
    {
        public MapperClass() {
            CreateMap<DetailHead, DetailHeadModel>();
            CreateMap<DetailHeadModel, DetailHead>();
            CreateMap<SubDetailHead, SubDetailHeadModel>();
            CreateMap<SubDetailHeadModel, SubDetailHead>();
                }
    }
}
