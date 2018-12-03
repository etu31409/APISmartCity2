using System;
using System.Collections.Generic;
using System.Linq;
using APISmartCity.Model;
namespace APISmartCity.DAO
{
    public class CommercesDAO
    {     
        public CommercesDAO(){   }
        private SCNConnectDBContext context = new SCNConnectDBContext();
        public List<Commerce> GetCommerces(){
            //BETTER Faire un include en plus pour avoir le nom de la catégorie et pas l'id (clé étrangère)
            IQueryable<Commerce> commerces = context.Commerce.Where(c => c.IdCategorie==2);
            return commerces.ToList();
        }

        public Commerce GetCommerce(int id){
            //Return du restaurant correspondant à l'identifiant passé en argument
            return GetCommerces().Find(c => c.IdCommerce == id);
        }

        public void ModifCommerce(Commerce commerce){
            //TODO Update du commerce dans la BD
        }

        public void AddCommerce(int id, Commerce commerce){
            //Les Id devraient pas etre accessible aux clients, seule une gestion interne !
            if (GetCommerces().Find(c => c.IdCommerce == id) != null){
                //Pas d'ajout et renvoie que id dejà occupé

                //Faire une verif backend sur le nom pour voir si le commerce existe deja et demander confirmation ?
            }
            //Ajout dans la BD
            context.Add<Commerce>(commerce);
            try{
                context.SaveChanges();
            }catch(Exception e){
                //TODO
                Console.WriteLine(e.Message);
            }
 
        }

        public void DeleteCommerce(int id){
            //TODO SUpprimer le commerce portant un certain id dans la BD
        }
    }
}