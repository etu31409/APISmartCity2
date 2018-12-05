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

namespace APISmartCity.Controllers
{
    //TODO mettre en place la reception du token d'identification
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommercesController : ControllerBase
    {
        private CommercesDAO commercesDAO = new CommercesDAO();
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commerce>>> Get()
        {
            List<Commerce> commerces = await commercesDAO.GetCommerces();
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
        public ActionResult<Commerce> Put(int id, [FromBody] Commerce commerce)
        {
            if (commerce == null)
                return NotFound();
            //fixme: InvalidOperationException: Sequence contains no matching element
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce
            if(commerce.IdPersonne != userId)
                return Forbid();

            commerce = commercesDAO.ModifCommerce(commerce);
            return Ok(commerce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Vérif si le commerce est présent
            if(commercesDAO.GetCommerce(id)==null)
                return NotFound();
            await commercesDAO.DeleteCommerce(id);
            return Ok();
        }
    }
}
