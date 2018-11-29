using System.Collections.Generic;
using APISmartCity.Model;
namespace APISmartCity.DAO
{
    public class RestaurantsDAO
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        private Address address = new Address();
        private List<string> moyensPayements = new List<string>() { };
        public RestaurantsDAO() { }

        public List<Restaurant> GetRestaurants()
        {
            restaurants.Add(new Restaurant(
                "BurgerKing",
                address,
                moyensPayements,
                "Restauration rapide",
                "Whooper",
                "Parcours produit phare",
                0483312007,
                061329068,
                "info@burger-king.com",
                "www.facebook.com/burger-king",
                456321
            ));
            return restaurants;
        }
    }
}