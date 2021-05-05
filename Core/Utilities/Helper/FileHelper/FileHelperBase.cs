using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Utilities.Helper.FileHelper
{
    public abstract class FileHelperBase : IFileHelper
    {
        protected void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public abstract IResult Delete(string fileName);

        protected string GetWWWRootPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        public abstract string Save(IFormFile formFile);

    }
}