using System.Collections.Generic;
using APISmartCity.Model;
namespace APISmartCity.DAO
{
    public class CommercesDAO
    {
        private List<Commerce> commerces = new List<Commerce>(){};
        private Address address = new Address("Rue de l'ange", 5000, 13);

        public CommercesDAO()
        {   
        }

        public List<Commerce> GetCommerces(){
            commerces.Add(new Commerce(1,"Commerce de test",address));
            commerces.Add(new Commerce(2,"Deuxième commerce de test",address));
            commerces.Add(new Commerce(3,"Troisième commerce de test",address));
            commerces.Add(new Commerce(4,"Quatrième commerce de test",address));
            commerces.Add(new Commerce(5,"Cinquième commerce de test",address));
            commerces.Add(new Commerce(6,"Sixième commerce de test",address));
            return commerces;
        }

        public Commerce GetCommerce(int id){
            //Return du restaurant correspondant à l'identifiant passé en argument
            //Laisser une erreur 204 ou lever une erreur 404 ?
            return GetCommerces().Find(c => c.CommerceId == id);
        }
    }
}