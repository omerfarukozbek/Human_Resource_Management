using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.Validations
{
    public class PhotoValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (extension == ".jpeg" || extension == ".png" || extension == ".jpg")
                    return true;
            }
            return true;
        }
    }
}
