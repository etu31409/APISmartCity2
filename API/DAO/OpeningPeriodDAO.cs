using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.ExceptionPackage;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;
using APISmartCity.DTO;

namespace APISmartCity.DAO
{
    public class OpeningPeriodDAO
    {     
        public OpeningPeriodDAO(){   }
        private SCNConnectDBContext context = new SCNConnectDBContext();
        public async Task<List<DTO.OpeningPeriod>> GetOpeningPeriods(){
           // return await context.Commerce.SelectMany(sm => sm.OpeningPeriod).Select(CreateDTOFromEntity);
           return new List<DTO.OpeningPeriod>();
        }

        public async Task<Commerce> GetCommerce(int id){
            //Return du restaurant correspondant à l'identifiant passé en argument
            return await context.Commerce.FirstOrDefaultAsync(c => c.IdCommerce == id);
        }

        public async Task<Commerce> ModifCommerce(Commerce entity, Commerce dto){
            //Gérer les accès concurents plus tard
            
            //Changer tout les champs de l'entity
                //fixme: Configurer un mapper
            entity.Numero = dto.Numero;

            await context.SaveChangesAsync();
            return entity;
        }

        public Model.Commerce AddCommerce(Commerce commerce){
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