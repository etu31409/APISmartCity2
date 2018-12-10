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
        
        private SCNConnectDBContext context;

        public OpeningPeriodDAO(SCNConnectDBContext context)
        {   
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DTO.OpeningPeriod CreateDTOFromEntity(Model.OpeningPeriod entity){
            //fixme: Possibilité d'amélioration avec un mapper
            return new DTO.OpeningPeriod()
            {
                Id = entity.IdHoraire,
                Opening = entity.HoraireDebut,
                Closing = entity.HoraireFin,
                Day = entity.Jour, //fixme: Trouver un truc pour dayOfWeek dans la db
                // on ne le stocke pas en DB car calculable, mais on facilite la vie
                // des applications clientes en le proposant dans le DTO!
                DurationOfOpening = entity.HoraireFin.Subtract(entity.HoraireDebut)
            };
        }

        private Model.OpeningPeriod CreateEntityFromDTO(DTO.OpeningPeriod dto){
            return new Model.OpeningPeriod(){
                IdHoraire = dto.Id,
                HoraireDebut = dto.Opening,
                HoraireFin = dto.Closing,
                Jour = dto.Day //fixme: Trouver un truc pour dayOfWeek dans la db
                // on ne le stocke pas en DB car calculable, mais on facilite la vie
                // des applications clientes en le proposant dans le DTO!
            };
        }

        public List<DTO.OpeningPeriod> GetOpeningPeriods(){
            return context.Commerce.SelectMany(sm => sm.OpeningPeriod).Select(CreateDTOFromEntity).ToList();
        }

        public Model.OpeningPeriod AddOpeningPeriod(Model.OpeningPeriod op){
            //Ajout dans la BD
            if(op == null)
                throw new OpeningPeriodNotFoundException();
            context.OpeningPeriod.Add(op);
            try{
                context.SaveChanges();
            }catch(Exception e){
                throw new CommerceNotFoundException(e.Message);
            }
            return op;
        }

        public async Task ModifOpeningPeriod(Model.OpeningPeriod entity, DTO.OpeningPeriod dto){
            entity = CreateEntityFromDTO(dto);
            context.Entry(entity).OriginalValues["RowVersion"] = dto.RowVersion;
            await context.SaveChangesAsync();
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