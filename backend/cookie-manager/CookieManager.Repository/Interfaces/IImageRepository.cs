using CookieManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
