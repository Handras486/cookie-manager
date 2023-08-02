﻿using CookieManager.Models;
using CookieManager.Repository;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImagesController(IImageRepository imageRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.imageRepository = imageRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageUploadRequest)
        {
            ValidateFileUpload(imageUploadRequest);

            if (ModelState.IsValid)
            {
                var imageDomain = new Image
                {
                    File = imageUploadRequest.File,
                    FileExtension = Path.GetExtension(imageUploadRequest.File.FileName),
                    FileSizeInBytes = imageUploadRequest.File.Length,
                    FileName = imageUploadRequest.FileName,
                    FileDescription = imageUploadRequest.FileDescription,
                };

                var serverUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
                await imageRepository.Upload(imageDomain, serverUrl);

                return Ok(imageDomain);
            }

            return BadRequest(ModelState);
        }

        //TODO move to logic layer later
        private void ValidateFileUpload(ImageUploadRequestDTO imageUploadRequest)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequest.File.FileName.ToLower())))
            {
                ModelState.AddModelError("file", "Unsupported file extension!");
            }

            if (imageUploadRequest.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please uploada smaller file!");
            }
        }
    }
}