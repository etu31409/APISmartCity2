using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APISmartCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercesController : ControllerBase
    {
        private List<Commerce> commerces = new List<Commerce>(){};
        private Address address = new Address("Rue de l'ange", "5550", 13);
        private List<string> moyensPayements = new List<string>(){};
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Commerce>> Get()
        {
            commerces.Add(new Commerce(
                5,
                "H&M",
                address
            ));
            return commerces;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
