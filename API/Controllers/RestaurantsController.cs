using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using APISmartCity.Model;
using APISmartCity.DAO;
namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private RestaurantsDAO restaurantsDAO = new RestaurantsDAO();
        private List<Restaurant> restaurants = new List<Restaurant>(){};
        private Address address = new Address();
        private List<string> moyensPayements = new List<string>(){};
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            User.Claims.ToList().ForEach(claim=>Console.WriteLine($"{claim.Type}: {claim.Value}"));

            return restaurantsDAO.GetRestaurants();
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
