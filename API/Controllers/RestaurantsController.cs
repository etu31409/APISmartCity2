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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Commerce>> Get()
        {
            List<Commerce> restaurants = restaurantsDAO.GetRestaurants();
            if (restaurants == null)
                return NotFound();
            return Ok(restaurants);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Commerce> Get(int id)
        {
            //Permet de récupérer le restaurant ayant comme ID 'id'
            var claim = User.Claims.First();

            Commerce restaurant = restaurantsDAO.GetRestaurant(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Commerce restaurant)
        {
            restaurantsDAO.ModifRestaurant(restaurant);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Commerce restaurant)
        {
            restaurantsDAO.AddRestaurant(id, restaurant);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO Verif que l'utilisateur a les droits
            restaurantsDAO.DeleteRestaurant(id);
            //Supprimer dans la base de données
        }
    }
}
