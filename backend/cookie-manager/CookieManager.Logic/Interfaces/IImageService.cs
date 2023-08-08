using CookieManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Service.Interfaces
{
    public interface IImageService
    {
        Task<Image> UploadImage(Image image, string serverUrl);
    }
}
