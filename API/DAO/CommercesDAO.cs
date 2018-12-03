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
            commerces = new List<Commerce>();
            commerces.Add(new Commerce(12,"Commerce de test",address));
            commerces.Add(new Commerce(16,"Deuxième commerce de test",address));
            commerces.Add(new Commerce(3,"Troisième commerce de test",address));
            commerces.Add(new Commerce(4,"Quatrième commerce de test",address));
            commerces.Add(new Commerce(5,"Cinquième commerce de test",address));
            commerces.Add(new Commerce(6,"Sixième commerce de test",address));
            return commerces;
        }
    }
}