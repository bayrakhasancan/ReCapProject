using Business.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator()
        {
            RuleFor(x => x.Length).LessThan(5000000).WithMessage(Messages.CarImageFileSizeError);
            RuleFor(x => x.FileName).Must(CheckExtension).WithMessage(Messages.CarImageExtensionError);
        }

        private bool CheckExtension(string fileName)
        {
            var entensionOfFile = Path.GetExtension(fileName).ToLowerInvariant();
            var permittedExtensions = new string[] { ".jpg", ".png" };

            foreach (var extension in permittedExtensions)
            {
                if (entensionOfFile == extension)
                {
                    return true;
                }
            }
            return false;
        }
    }
}