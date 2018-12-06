using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.ExceptionPackage;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;

namespace APISmartCity.DAO
{
    public class CommercesDAO
    {     
        public CommercesDAO(){   }
        private SCNConnectDBContext context = new SCNConnectDBContext();
        public async Task<List<Commerce>> GetCommerces(int categorie){
            //BETTER Faire un include en plus pour avoir le nom de la catégorie et pas l'id (clé étrangère)
            return await context.Commerce.Where( c => categorie == 0 || c.IdCategorie == categorie).ToListAsync();
        }

        public async Task<Commerce> GetCommerce(int id){
            //Return du restaurant correspondant à l'identifiant passé en argument
            return await context.Commerce.FirstOrDefaultAsync(c => c.IdCommerce == id);
        }

        public Commerce ModifCommerce(Commerce commerce){
            //Gérer les accès concurents plus tard
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
            if(commerce == null)
                throw new CommerceNotFoundException();
            context.Commerce.Add(commerce);
            try{
                context.SaveChanges();
            }catch(Exception e){
                throw new CommerceNotFoundException(e.Message);
            }
            return commerce;
            //TODO Faire un catch de l'excpetion pour la renvoyer au client vie FILTER
        }

        public async Task DeleteCommerce(Commerce commerce){               
            try{
                context.Remove(commerce);
                await context.SaveChangesAsync();
            }catch(Exception e){
                //TODO
                Console.WriteLine(e.Message);
            }
        }
    }
}