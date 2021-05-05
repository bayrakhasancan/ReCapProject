using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        string Save(IFormFile formFile);
        IResult Delete(string fileName);
    }
}
