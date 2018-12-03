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
            restaurants.Add(new Restaurant(
                "Quick",
                address,
                moyensPayements,
                "Restauration rapide",
                "Giant",
                "Parcours produit phare",
                0483312007,
                061329068,
                "info@quick.com",
                "www.facebook.com/quick",
                456321
            ));
            restaurants.Add(new Restaurant(
                "KFC",
                address,
                moyensPayements,
                "Restauration rapide",
                "Saut de poulet",
                "Parcours produit phare",
                0483312007,
                061329068,
                "info@KFC.com",
                "www.facebook.com/kfc",
                456321
            ));
            restaurants.Add(new Restaurant(
                "Zara",
                address,
                moyensPayements,
                "Pret à porter féminin",
                "Echarpe de Noel",
                "Parcours produit phare",
                0483312007,
                061329068,
                "info@Zara.com",
                "www.facebook.com/Zara",
                456321
            ));
            return restaurants;
        }

        public Restaurant GetRestaurant(int idProprio){
            List<Restaurant> restaurants = GetRestaurants();
            return new Restaurant(
                "Resto test id",
                address,
                moyensPayements,
                "Restauration rapide",
                "Whooper",
                //Test de recup idProprio
                "idProprio : "+idProprio,
                0483312007,
                061329068,
                "info@burger-king.com",
                "www.facebook.com/burger-king",
                456321
            );
        }
    }
}