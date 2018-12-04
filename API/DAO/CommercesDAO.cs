using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;

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

        public Commerce ModifCommerce(Commerce commerce){
            if (context.Entry(commerce).State == EntityState.Detached)
            {
                context.Attach(commerce).State = EntityState.Modified;
            }
            // regardez également aux versions asynchrones des méthodes!
            context.SaveChanges();
            return commerce;
        }

        public Commerce AddCommerce(Commerce commerce){
            //Ajout dans la BD
            context.Commerce.Add(commerce);
            try{
                context.SaveChanges();
            }catch(Exception e){
                //TODO
                Console.WriteLine(e.Message);
            }
            return commerce;
            //TODO Faire un catch de l'excpetion pour la renvoyer au client vie FILTER
        }

        public async Task DeleteCommerce(int id){
            context.Remove(context.Commerce.FirstOrDefault(c => c.IdCommerce == id));
            try{
                await context.SaveChangesAsync();
            }catch(Exception e){
                //TODO
                Console.WriteLine(e.Message);
            }
        }
    }
}