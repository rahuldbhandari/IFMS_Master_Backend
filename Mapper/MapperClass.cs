using AutoMapper;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL;

namespace IFMS_Master_Backend.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass() 
        {
            CreateMap<MajorHeadModel, MajorHead>().ReverseMap();
            CreateMap<SubMajorHeadModel, SubMajorHead>().ReverseMap();
            CreateMap<MinorHeadModel, MinorHead>().ReverseMap();
            CreateMap<Detailhead, DetailHeadModel>();
            CreateMap<DetailHeadModel, Detailhead>();
            CreateMap<SubDetailHead, SubDetailHeadModel>();
            CreateMap<SubDetailHeadModel, SubDetailHead>();
        }
    }
}
