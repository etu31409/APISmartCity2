using System;
using APISmartCity.Model;
using APISmartCity.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
        public ActionResult<IEnumerable<Commerce>> Get()
        {
            //TODO Faire une vérif de l'ultilisateur qui appelle le controlleur pour lui renvoyer que ses commerces.
            //var claim = User.Claims.First();
            List<Commerce> commerces = commercesDAO.GetCommerces();
            if (commerces == null)
                return NotFound();
            return Ok(commerces);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Commerce> Get(int id)
        {
            Commerce commerce = commercesDAO.GetCommerce(id);
            if(commerce == null)
                return NotFound();
            return commerce;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Commerce commerce)
        {
            commercesDAO.ModifCommerce(commerce);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Commerce commerce)
        {
            commercesDAO.AddCommerce(id, commerce);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            commercesDAO.DeleteCommerce(id);
        }
    }
}
