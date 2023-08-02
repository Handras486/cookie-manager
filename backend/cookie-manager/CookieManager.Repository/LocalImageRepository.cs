using CookieManager.Data;
using CookieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly CookieManagerDbContext dbContext;

        public LocalImageRepository(CookieManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Image> Upload(Image image, string serverUrl)
        {
            var localFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", $"{image.FileName}{image.FileExtension}");

            var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{serverUrl}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
