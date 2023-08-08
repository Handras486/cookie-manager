using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository.Interfaces
{
    public interface ICookieRepository
    {
        Task<List<Cookie>> GetAllAsync(CookieQueryParameters queryParameters);

        Task<Cookie?> GetAsync(Guid id);

        Task<Cookie> CreateAsync(Cookie cookie);

        Task<Cookie?> UpdateAsync(Guid id, Cookie cookie);

        Task<Cookie?> DeleteAsync(Guid id);
    }
}
