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
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commerce>>> Get()
        {
            //TODO Faire une vérif de l'ultilisateur qui appelle le controlleur pour lui renvoyer que ses commerces.
            //var claim = User.Claims.First();
            List<Commerce> commerces = await commercesDAO.GetCommerces();
            if (commerces == null)
                return NotFound();
            return Ok(commerces);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commerce>> Get(int id)
        {
            Commerce commerce = await commercesDAO.GetCommerce(id);
            if(commerce == null)
                return NotFound();
            return Ok(commerce);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Commerce> Post([FromBody] Commerce commerce)
        {   //TODO Revoie la méthode POST
            commerce = commercesDAO.AddCommerce(commerce);
            return Created("api/Commerces/" + commerce.IdCommerce, commerce);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Commerce> Put(int id, [FromBody] Commerce commerce)
        {
            if (commerce == null)
                return NotFound();
            commerce = commercesDAO.ModifCommerce(commerce);
            return Ok(commerce);
        }

        // DELETE api/values/5
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
