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

        public DTO.OpeningPeriodDTO CreateDTOFromEntity(Model.OpeningPeriod entity)
        {
            //fixme: Possibilité d'amélioration avec un mapper
            return new DTO.OpeningPeriodDTO()
            {
                IdHoraire = entity.IdHoraire,
                HoraireDebut = entity.HoraireDebut,
                HoraireFin = entity.HoraireFin,
                Jour = entity.Jour,
                IdCommerce = entity.IdCommerce,
                DureeOuverture = entity.HoraireFin.Subtract(entity.HoraireDebut)
            };
        }
        private Model.OpeningPeriod CreateEntityFromDTO(DTO.OpeningPeriodDTO dto)
        {
            return new Model.OpeningPeriod()
            {
                HoraireDebut = dto.HoraireDebut,
                HoraireFin = dto.HoraireDebut,
                Jour = dto.Jour,
                IdCommerce = dto.IdCommerce
            };
            //return new Model.OpeningPeriod(dto.HoraireDebut, dto.HoraireFin, dto.Jour, dto.IdCommerce);
        }

        public async Task<List<Model.OpeningPeriod>> GetOpeningPeriods()
        {
            return await context.OpeningPeriod.ToListAsync();
        }

        public async Task<Model.OpeningPeriod> AddOpeningPeriod(Model.OpeningPeriod op, Model.Commerce commerce)
        {
            if (op == null)
                throw new OpeningPeriodNotFoundException();
            
            commerce.AddOpeningPeriod(op);
            await context.SaveChangesAsync();
            return op;
        }

        public async Task ModifOpeningPeriod(Model.OpeningPeriod entity, DTO.OpeningPeriodDTO dto)
        {
            //entity = CreateEntityFromDTO(dto);
            entity.HoraireDebut = dto.HoraireDebut;
            entity.HoraireFin= dto.HoraireFin;
            entity.Jour = dto.Jour;
            context.Entry(entity).OriginalValues["RowVersion"] = dto.RowVersion;
            if(context.OpeningPeriod
            .Where(existingPeriod => existingPeriod.IdHoraire != entity.IdHoraire)
            .Any(existingPeriod =>
                existingPeriod.Jour == entity.Jour &&(
                    (entity.HoraireFin >= existingPeriod.HoraireDebut && entity.HoraireFin <= existingPeriod.HoraireFin) ||
                    (entity.HoraireDebut >= existingPeriod.HoraireDebut && entity.HoraireDebut <= existingPeriod.HoraireFin) ||
                    (entity.HoraireDebut <= existingPeriod.HoraireDebut && entity.HoraireFin >= existingPeriod.HoraireFin)))
                ){
                    throw new InvalidOpeningPeriodException();
                }
            await context.SaveChangesAsync();
        }

        public async Task DeleteOpeningPeriod(Model.OpeningPeriod op)
        {
            if(op == null)
                throw new OpeningPeriodNotFoundException();
            context.Remove(op);
            await context.SaveChangesAsync();
        }

        public async Task<Commerce> getCommerceOpeningPeriod(int commerceId)
        {
            CommercesDAO commercesDAO = new CommercesDAO(context);
            return await commercesDAO.GetCommerce(commerceId);
        }
    }
}