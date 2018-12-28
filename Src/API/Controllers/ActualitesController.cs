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
        
        // GET api/OpeningPeriod/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Model.Actualite entity = await actualitesDAO.GetActualite(id);
            return (entity == null) ? NotFound() : (IActionResult)Ok(Mapper.Map<ActualiteDTO>(entity));
        }

        // private Task<Model.Actualite> FindActualiteById(int id)
        // {
        //     return context.Actualite.FirstOrDefaultAsync(actu => actu.IdActualite == id);
        // }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActualiteDTO actuDto)
        {
            Actualite entity = await actualitesDAO.GetActualite(id);
            if (entity == null)
                return NotFound();
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            // if(entity.IdCommerceNavigation.IdUser != userId && !User.IsInRole(Constants.Roles.Admin))
            Commerce commerce = await actualitesDAO.getCommerceActualite(actuDto.IdCommerce.GetValueOrDefault());
            if(commerce.IdUser != userId && !User.IsInRole(Constants.Roles.Admin))
                 return Forbid();
            await actualitesDAO.UpdateActualite(entity, actuDto);
            return Ok(Mapper.Map<ActualiteDTO>(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Actualite actualite = await actualitesDAO.GetActualite(id);
            if(actualite==null)
                return NotFound();
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            //if(actualite.IdCommerceNavigation.IdUser != userId && !User.IsInRole(Constants.Roles.Admin))
            Commerce commerce = await actualitesDAO.getCommerceActualite(actualite.IdCommerce.GetValueOrDefault());
            if(commerce.IdUser != userId && !User.IsInRole(Constants.Roles.Admin))
                return Forbid();
            await actualitesDAO.DeleteActualite(actualite);
            return Ok();
        }
    }
}
