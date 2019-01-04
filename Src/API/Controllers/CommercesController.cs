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
    public class CommercesController : ControllerBase
    {
        private SCNConnectDBContext context;
        private CommercesDAO commercesDAO;
        public CommercesController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.commercesDAO = new CommercesDAO(context);
        }
        
        
        [HttpGet]
        [Authorize(Roles = Constants.Roles.ADMIN)]
        [Authorize(Roles = Constants.Roles.USER)]
        public async Task<ActionResult<IEnumerable<Commerce>>> Get(int categorie = 0, bool all = true)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            List<Commerce> commerces = await commercesDAO.GetCommerces(categorie, userId, all);
            if (commerces == null)
                return NotFound();
            //return Ok(commerces);
            return Ok(Mapper.Map<List<CommerceDTO>>(commerces));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Constants.Roles.ADMIN)]
        [Authorize(Roles = Constants.Roles.USER)]
        public async Task<ActionResult<Commerce>> GetById(int id)
        {
            Commerce commerce = await commercesDAO.GetCommerce(id);
            if(commerce == null)
                return NotFound();
            return Ok(Mapper.Map<CommerceDTO>(commerce));
        }

        [HttpPost]
        [Authorize(Roles = Constants.Roles.ADMIN)]
        public async Task<ActionResult> Post([FromBody] CommerceDTO commerce)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            Commerce entity = Mapper.Map<Commerce>(commerce);
            entity = await commercesDAO.AddCommerce(entity);  
            return Created($"api/Commerces/{commerce.IdCommerce}", Mapper.Map<CommerceDTO>(entity));
        }

        [HttpPut]
        [Authorize(Roles = Constants.Roles.ADMIN)]
        public async Task<ActionResult> Put([FromBody] Commerce commerce)
        {
            Commerce entity = await commercesDAO.GetCommerce(commerce.IdCommerce);
            if (entity == null)
                return NotFound();
            
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //if(entity.IdUser != userId && !User.IsInRole(Constants.Roles.ADMIN))
            if(entity.IdUser != userId)
                return Forbid();

            await commercesDAO.ModifCommerce(entity, commerce);
            return Ok(commerce);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.Roles.ADMIN)]
        public async Task<ActionResult> Delete(int id)
        {
            Commerce commerce = await commercesDAO.GetCommerce(id);
            if(commerce==null)
                return NotFound();
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //if(commerce.IdUser != userId && !User.IsInRole(Constants.Roles.ADMIN))
            if(commerce.IdUser != userId)
                return Forbid();
            await commercesDAO.DeleteCommerce(commerce);
            return Ok();
        }
    }
}
