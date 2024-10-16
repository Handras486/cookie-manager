﻿using CookieManager.Core.Specifications;
using CookieManager.Repository.Interfaces;
using CookieManager.Service.Interfaces;
using Cookie = CookieManager.Core.Entities.Cookie;
using AutoMapper;

namespace CookieManager.Service
{
    public class CookieService : ICookieService
    {
        private readonly ICookieRepository cookieRepository;
        private readonly IMapper mapper;

        public CookieService(ICookieRepository cookieRepository, IMapper mapper)
        {
            this.cookieRepository = cookieRepository;
            this.mapper = mapper;
        }

        public async Task<Cookie> CreateCookieAsync(Cookie createCookie)
        {
            await cookieRepository.CreateAsync(createCookie);
            return createCookie;
        }

        public async Task<Cookie?> DeleteCookieAsync(Guid id)
        {
            var deletedCookie = await cookieRepository.DeleteAsync(id);
            return deletedCookie;
        }

        public async Task<List<Cookie>> GetAllCookiesAsync(CookieQueryParameters queryParameters)
        {

            if (!string.IsNullOrWhiteSpace(queryParameters.filterOn) && !string.IsNullOrEmpty(queryParameters.filterQuery))
            {
                if (queryParameters.filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    queryParameters.filterOn = "Name";
            }
            else
            {
                queryParameters.filterOn = null;
            }

            if (!string.IsNullOrWhiteSpace(queryParameters.sortBy))
            {
                if (queryParameters.sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    queryParameters.sortBy = "Name";
            }
            else
            {
                queryParameters.sortBy = null;
            }

            var allCookies = await cookieRepository.GetAllAsync(queryParameters);
            return allCookies;
        }

        public async Task<Cookie?> GetCookieAsync(Guid id)
        {
            return await cookieRepository.GetAsync(id); 
        }

        public async Task<Cookie?> UpdateCookieAsync(Guid id, Cookie cookie)
        {
            var updateCookie = await cookieRepository.UpdateAsync(id, cookie);

            mapper.Map(cookie, updateCookie);

            return updateCookie;
        }
    }
}
