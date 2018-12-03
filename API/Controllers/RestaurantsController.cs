﻿using System;
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
        private List<Restaurant> restaurants = new List<Restaurant>() { };
        private Address address = new Address();
        private List<string> moyensPayements = new List<string>() { };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            //Permet de Récupérer tout les restaurants
                //Permet de lister la liste des claims
                //User.Claims.ToList().ForEach(claim => Console.WriteLine($"{claim.Type}: {claim.Value}"));

            //TODO Faire une vérif de l'ultilisateur qui appelle le controlleur pour lui renvoyer que ses restaurants.
            var claim = User.Claims.First();

            return restaurantsDAO.GetRestaurants();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            //Permet de récupérer le restaurant ayant comme ID 'id'
            var claim = User.Claims.First();

            return restaurantsDAO.GetRestaurant(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Restaurant restaurant)
        {
            restaurantsDAO.ModifRestaurant(restaurant);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Restaurant restaurant)
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