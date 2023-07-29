﻿using CookieManager.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository
{
    public interface ICookieRepository
    {
        Task<List<Cookie>> GetAllAsync();

        Task<Cookie?> GetAsync(Guid id);

        Task<Cookie> CreateAsync(Cookie cookie);

        Task<Cookie?> UpdateAsync(Guid id, Cookie cookie);

        Task<Cookie?> DeleteAsync(Guid id);
    }
}