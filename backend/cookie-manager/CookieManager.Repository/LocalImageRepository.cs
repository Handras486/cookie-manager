using CookieManager.Core.Entities;
using CookieManager.Data;
using CookieManager.Repository.Interfaces;
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

        public async Task<Image> Upload(Image image)
        {
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
