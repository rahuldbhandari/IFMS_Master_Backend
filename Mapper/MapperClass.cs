using AutoMapper;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<MajorHeadModel, MajorHead>().ReverseMap();
            CreateMap<SubMajorHeadModel, SubMajorHead>().ReverseMap();
            CreateMap<MinorHeadModel, MinorHead>().ReverseMap();
            CreateMap<DetailHead, DetailHeadModel>().ReverseMap();
            CreateMap<SubDetailHead, SubDetailHeadModel>().ReverseMap();
            CreateMap<DdoModel, Ddo>().ReverseMap();
            CreateMap<Treasury, TreasuryModel>().ReverseMap();

        }
    }
}
