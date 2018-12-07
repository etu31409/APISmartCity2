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
        public OpeningPeriodDAO(){  }
        private SCNConnectDBContext context;

        public OpeningPeriodDAO(SCNConnectDBContext context)
        {   //Question : Passer par des méthodes statiques ?
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DTO.OpeningPeriod CreateDTOFromEntity(Model.OpeningPeriod entity){
            //fixme: Possibilité d'amélioration avec un mapper
            return new DTO.OpeningPeriod()
            {
                Id = entity.IdHoraire,
                Opening = entity.HoraireDebut,
                Closing = entity.HoraireFin,
                //Day = entity.Jour, --Trouver un truc pour dayOfWeek dans la db
                // on ne le stocke pas en DB car calculable, mais on facilite la vie
                // des applications clientes en le proposant dans le DTO!
                DurationOfOpening = entity.HoraireFin.Subtract(entity.HoraireDebut)
            };
        }

        public List<DTO.OpeningPeriod> GetOpeningPeriods(){
            //fixme : Pourquoi pas de ToListAsync() ?
            return context.Commerce.SelectMany(sm => sm.OpeningPeriod).Select(CreateDTOFromEntity).ToList();
        }

        public async Task<Commerce> GetOpeningPeriod(int id){
            //Utilité d'une telle méthode ?
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