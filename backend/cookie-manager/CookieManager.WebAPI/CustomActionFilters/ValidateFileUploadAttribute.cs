using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CookieManager.WebAPI.CustomActionFilters
{
    public class ValidateFileUploadAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            var imageUploadRequest = context.ActionArguments["imageUploadRequest"] as ImageUploadRequestDTO;

            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequest.File.FileName.ToLower())))
            {
                context.ModelState.AddModelError("file", "Unsupported file extension!");
            }

            if (imageUploadRequest.File.Length > 10485760)
            {
                context.ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller file!");
            }
        }
    }
}
