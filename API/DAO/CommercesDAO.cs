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
            context.Remove(context.Commerce.FirstOrDefault(c => c.IdCommerce == id));
            try{
                context.SaveChanges();
            }catch(Exception e){
                //TODO
                Console.WriteLine(e.Message);
            }
        }
    }
}