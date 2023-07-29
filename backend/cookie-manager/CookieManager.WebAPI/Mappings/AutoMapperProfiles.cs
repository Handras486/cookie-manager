using AutoMapper;
using CookieManager.Models;
using CookieManager.WebAPI.DTO;

namespace CookieManager.WebAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cookie, CookieDTO>().ReverseMap();
            CreateMap<AddCookieRequestDTO, Cookie>().ReverseMap();
            CreateMap<UpdateCookieRequestDTO, Cookie>().ReverseMap();
        }
    }
}
