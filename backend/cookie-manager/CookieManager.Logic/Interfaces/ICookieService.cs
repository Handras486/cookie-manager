using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Service.Interfaces
{
    public interface ICookieService
    {
        Task<List<Cookie>> GetAllCookiesAsync(CookieQueryParameters queryParameters);

        Task<Cookie?> GetCookieAsync(Guid id);

        Task<Cookie> CreateCookieAsync(Cookie cookie);

        Task<Cookie?> UpdateCookieAsync(Guid id, Cookie cookie);

        Task<Cookie?> DeleteCookieAsync(Guid id);
    }
}
