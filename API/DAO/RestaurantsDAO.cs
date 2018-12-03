using System.Collections.Generic;
using System.Linq;
using APISmartCity.Model;
namespace APISmartCity.DAO
{
    public class RestaurantsDAO
    {
        public RestaurantsDAO() { }

        public List<Commerce> GetRestaurants()
        {
            var context = new SCNConnectDBContext();
            //BETTER Faire un include en plus pour avoir le nom de la catégorie et pas l'id (clé étrangère)
            IQueryable<Commerce> restaurants = context.Commerce.Where(c => c.IdCategorie==1);
            return restaurants.ToList();
        }

        public Commerce GetRestaurant(int id){
            List<Commerce> restaurants = GetRestaurants();
            return GetRestaurants().Find(restaurant => restaurant.IdCommerce == id);
        }

        public void ModifRestaurant(Commerce restaurant){
            //TODO Modifier le restaurant dans la BD
        }

        public void AddRestaurant(int id, Commerce restaurant){
            //TODO Ajouter un restaurant dans la BD
        }

        public void DeleteRestaurant(int id){
            // TODO Suprimer le restaurant dans la BD
        }
    }
}