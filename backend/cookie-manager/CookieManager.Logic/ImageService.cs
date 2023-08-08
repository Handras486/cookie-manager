using CookieManager.Core.Entities;
using CookieManager.Repository.Interfaces;
using CookieManager.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieManager.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<Image> UploadImage(Image image, string serverUrl)
        {
            var localFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", $"{image.FileName}{image.FileExtension}");

            var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{serverUrl}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            var uploadedImage = await imageRepository.Upload(image);
            return uploadedImage;
        }

    }
}
