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
            commerces.Add(new Commerce(1,"Premier commerce de test",address));
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

        public void ModifCommerce(Commerce commerce){
            //TODO Update du commerce dans la BD
        }

        public void AddCommerce(int id, Commerce commerce){
            //Les Id devraient pas etre accessible aux clients, seule une gestion interne !
            if (GetCommerces().Find(c => c.CommerceId == id) != null){
                //Pas d'ajout et renvoie que id dejà occupé

                //Faire une verif backend sur le nom pour voir si le commerce existe deja et demander confirmation ?
            }
            //Ajout dans la BD
        }

        public void DeleteCommerce(int id){
            //TODO SUpprimer le commerce portant un certain id dans la BD
        }
    }
}