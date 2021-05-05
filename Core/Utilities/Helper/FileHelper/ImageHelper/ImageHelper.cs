using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper.FileHelper.ImageHelper
{
    public class ImageHelper : FileHelperBase
    {
        readonly string _pathOfImagesFolder;
        public ImageHelper()
        {
            _pathOfImagesFolder = Path.Combine(GetWWWRootPath(), "Images");

            CreateDirectoryIfNotExists(_pathOfImagesFolder);
        }

        public override IResult Delete(string fileName)
        {
            string imagePathToDelete = Path.Combine(fileName);

            if (File.Exists(imagePathToDelete))
            {
                File.Delete(imagePathToDelete);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public override string Save(IFormFile formFile)
        {
            string guidNumber = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(formFile.FileName);
            string imagePathToSave = Path.Combine(_pathOfImagesFolder, guidNumber) + extension;

            using (var stream = File.Create(imagePathToSave))
            {
                formFile.CopyTo(stream);
            }

            return imagePathToSave;
        }
    }
}
