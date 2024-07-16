using AutoMapper;
using CookieManager.Core.Entities;
using CookieManager.WebAPI.DTO;

namespace CookieManager.WebAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDTO>().ReverseMap();

            CreateMap<Cookie, Cookie>();
            CreateMap<Cookie, CookieDTO>().ReverseMap();
            CreateMap<Cookie, AddCookieRequestDTO>().ReverseMap();
            CreateMap<Cookie, UpdateCookieRequestDTO>().ReverseMap();

        }
    }
}
