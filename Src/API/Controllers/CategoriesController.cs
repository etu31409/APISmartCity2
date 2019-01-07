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
using AutoMapper;
using APISmartCity.DTO;
using Microsoft.EntityFrameworkCore;

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private SCNConnectDBContext context;
        private categorieDAO categorieDAO;
        public CategoriesController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.categorieDAO = new categorieDAO(context);
        }
        
        [HttpGet]
        [Authorize(Roles = Constants.Roles.USER)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DTO.CommerceDTO>))]
        public async Task<ActionResult<IEnumerable<Commerce>>> Get()
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            List<Categorie> categories = await categorieDAO.GetCategories();
            if (categories == null)
                return NotFound();
            return Ok(Mapper.Map<List<CategorieDTO>>(categories));
        }
    }
}
