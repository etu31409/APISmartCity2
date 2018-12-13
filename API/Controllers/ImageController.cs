using System;
using APISmartCity.Model;
using APISmartCity.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using APISmartCity.ExceptionPackage;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System.IO;
using CloudinaryDotNet.Actions;

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        CloudinaryDotNet.Cloudinary _cloudinary;
        private SCNConnectDBContext context;
        public ImageController(SCNConnectDBContext context)
        {
            Account account  = new Account("dtf5i3kcx","331395718795461","jAAPUe06bLnqQbogzB5nREwJBRQ"/*a cplt avec les clefs*/);
          _cloudinary = new Cloudinary(account);        
        }
        [HttpPost]
      public IActionResult PostAsync(IFormFile file)
      {
          var filePath = Path.GetTempFileName();
          if (file.Length > 0)
          {
              using (var stream = file.OpenReadStream())
              {
                  ImageUploadResult results = _cloudinary.Upload(new ImageUploadParams()
                  {
                      File = new FileDescription(file.Name, stream)
                  });
                  if (results.Error == null)
                      return Ok(results.Uri);
                  else
                      return BadRequest(results.Error.Message);
              }
                  
          }
          return BadRequest("Unsupported format");
        }
    }
}

