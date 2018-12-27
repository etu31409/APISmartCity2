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

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ActualitesController : ControllerBase
    {
        private SCNConnectDBContext context;
        private ActualitesDAO actualitesDAO;
        public ActualitesController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.actualitesDAO = new ActualitesDAO(context);
        }
        
        [HttpPost]
        //[Authorize(Roles = Constants.Roles.Admin)]
        public async Task<ActionResult> Post([FromBody] ActualiteDTO dto)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            Actualite entity = Mapper.Map<Model.Actualite>(dto);
            entity = await actualitesDAO.AddActualite(entity);  
            return Created($"api/Actualites/{dto.IdActualite}", Mapper.Map<ActualiteDTO>(entity));
        }
        
    }
}
