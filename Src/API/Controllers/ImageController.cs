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
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace APISmartCity.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        private SCNConnectDBContext context;
        private CloudinaryDotNet.Cloudinary cloudinary;
        private CommercesDAO commercesDAO;
        public ImageController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            cloudinary = new Cloudinary(new Account("dtf5i3kcx", "331395718795461", "jAAPUe06bLnqQbogzB5nREwJBRQ"));
            this.commercesDAO = new CommercesDAO(context);
        }

        [HttpPost()]
        [ProducesResponseType(201, Type = typeof(DTO.ImageCommerceDTO))]
        public async Task<IActionResult> Post()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                return BadRequest($"Expected a multipart request, but got {Request.ContentType}");
            }

            // Used to accumulate all the form url encoded key value pairs in the 
            // request.
            var formAccumulator = new KeyValueAccumulator();
            string targetFilePath = null;

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);

            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                ContentDispositionHeaderValue contentDisposition;
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out contentDisposition);

                if (hasContentDispositionHeader)
                {
                    //Passe pas ici car ne considere pas le form data en file mais en clé + valeur
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        targetFilePath = Path.GetTempFileName();
                        using (var targetStream = System.IO.File.Create(targetFilePath))
                        {
                            await section.Body.CopyToAsync(targetStream);
                        }
                    }
                    else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                    {
                        var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                        var encoding = GetEncoding(section);
                        using (var streamReader = new StreamReader(
                            section.Body,
                            encoding,
                            detectEncodingFromByteOrderMarks: true,
                            bufferSize: 1024,
                            leaveOpen: true))
                        {
                            // The value length limit is enforced by MultipartBodyLengthLimit
                            var value = await streamReader.ReadToEndAsync();
                                
                            {
                                value = String.Empty;
                            }
                            //Value = ""
                            formAccumulator.Append(key.ToString(), value);

                            if (formAccumulator.ValueCount > _defaultFormOptions.ValueCountLimit)
                            {
                                throw new InvalidDataException($"Form key count limit {_defaultFormOptions.ValueCountLimit} exceeded.");
                            }
                        }
                    }
                }
                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }
            string str = formAccumulator.GetResults()["IdCommerce"];
            int idCommerce = int.Parse(formAccumulator.GetResults()["IdCommerce"].ToString());
            //int idCommerce = 35;
            Commerce entity = await commercesDAO.GetCommerce(idCommerce);
            if (entity == null) return NotFound("Commerce non trouvé" + idCommerce);

            ImageUploadResult results = cloudinary.Upload(new ImageUploadParams()
            {
                File = new FileDescription(targetFilePath)
            });


            entity.AddImage(results.Uri.ToString(), idCommerce);
            await context.SaveChangesAsync();

            return Ok(results.Uri);
        }

        private static Encoding GetEncoding(MultipartSection section)
        {
            MediaTypeHeaderValue mediaType;
            var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out mediaType);
            // UTF-7 is insecure and should not be honored. UTF-8 will succeed in 
            // most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }
            return mediaType.Encoding;
        }

        [HttpDelete]
        [ProducesResponseType(204, Type = typeof(DTO.FavorisDTO))]
        public async Task<ActionResult> Delete(int idImage, int idCommerce)
        {
            Commerce commerce = await commercesDAO.GetCommerce(idCommerce);
            if (commerce == null)
                return NotFound("Commerce non trouvé" + idCommerce);

            ImageCommerce img = commerce.ImageCommerce.FirstOrDefault(i => i.IdImageCommerce == idImage);
            if (img != null)
                context.Remove(img);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

