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

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommercesController : ControllerBase
    {
        private CommercesDAO commercesDAO = new CommercesDAO();
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commerce>>> Get(int categorie=0)
        {
            //L'attribut permet de définir la catégorie que on veut
            List<Commerce> commerces = await commercesDAO.GetCommerces(categorie);
            if (commerces == null)
                return NotFound();
            return Ok(commerces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commerce>> GetById(int id)
        {
            Commerce commerce = await commercesDAO.GetCommerce(id);
            if(commerce == null)
                return NotFound();
            return Ok(commerce);
        }

        [HttpPost]
        public ActionResult<Commerce> Post([FromBody] Commerce commerce)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            commerce = commercesDAO.AddCommerce(commerce);
            return Created($"api/Commerces/{commerce.IdCommerce}", commerce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] Commerce commerce)
        {
            Commerce entity = await commercesDAO.GetCommerce(id);
            if (entity == null)
                return NotFound();
            
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            if(entity.IdPersonne != userId && !User.IsInRole(Constants.Roles.Admin))
                return Forbid();

            commerce = await commercesDAO.ModifCommerce(entity, commerce);
            return Ok(commerce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Commerce commerce = await commercesDAO.GetCommerce(id);
            if(commerce==null)
                return NotFound();
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            if(commerce.IdPersonne != userId && !User.IsInRole(Constants.Roles.Admin))
                return Forbid();
            await commercesDAO.DeleteCommerce(commerce);
            return Ok();
        }
    }
}
