using AutoMapper;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.Models;

namespace IFMS_Master_Backend.Mapper
{
    public class MapperClass:Profile
    {
        public MapperClass()
        {
            CreateMap<TreasuryModel,Treasury>().ReverseMap();
            CreateMap<DdoModel,Ddo>().ReverseMap();
        }
    }
}
