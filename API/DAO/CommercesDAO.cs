using System.Collections.Generic;
using APISmartCity.Model;
namespace APISmartCity.DAO
{
    public class CommercesDAO
    {
        private List<Commerce> commerces = new List<Commerce>(){};
        private Address address = new Address("Rue de l'ange", "5550", 13);
        private List<string> moyensPayements = new List<string>(){};

        public CommercesDAO()
        {   
        }

        public List<Commerce> GetCommerces(){
            commerces = new List<Commerce>();
            commerces.Add(new Commerce(12,"Commerce de test",address));
            return commerces;
        }
    }
}