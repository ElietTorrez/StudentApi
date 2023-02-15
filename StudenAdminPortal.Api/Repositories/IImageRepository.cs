using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Repositories
{
  public interface IImageRepository
    {

        Task<string> upload(IFormFile file, string fileName);
    }
}
