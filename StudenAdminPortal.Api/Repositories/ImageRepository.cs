using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public async Task<string> upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Imagenes", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRuta(fileName);
        }

        private string GetRuta(string fileName)
        {
            return Path.Combine(@"Resources\Imagenes", fileName);
        }
    }
}
