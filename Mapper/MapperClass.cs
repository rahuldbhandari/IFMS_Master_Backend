using AutoMapper;

using IFMS_Master_Backend.Models;
using IFMS_Master_Backend.DAL.Entities;

namespace DetailHead.Helper
{
    public class MapperClass : Profile
    {
        public MapperClass() {
            CreateMap<Detailhead, DetailHeadModel>();
            CreateMap<DetailHeadModel, Detailhead>();
            CreateMap<SubDetailHead, SubDetailHeadModel>();
            CreateMap<SubDetailHeadModel, SubDetailHead>();
                }
    }
}
