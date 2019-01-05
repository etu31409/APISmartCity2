using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.ExceptionPackage;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;
using APISmartCity.DTO;
using AutoMapper;
namespace APISmartCity.DAO
{
    public class ActualitesDAO
    {
        private SCNConnectDBContext context;
        public ActualitesDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Model.Actualite> AddActualite(Actualite actualite)
        {
            if (actualite == null)
                throw new ActualiteNotFoundException();
            context.Actualite.Add(actualite);
            await context.SaveChangesAsync();
            return actualite;
        }

        public async Task<Actualite> GetActualite(int id)
        {
            return await context.Actualite.FirstOrDefaultAsync(c => c.IdActualite == id);
        }

        public async Task UpdateActualite(Actualite entity, ActualiteDTO actuDto)
        {
            //entity = Mapper.Map<Actualite>(actuDto);
            entity.Libelle = actuDto.Libelle;
            entity.Texte = actuDto.Texte;
            entity.Date = actuDto.Date;
            context.Entry(entity).OriginalValues["RowVersion"] = actuDto.RowVersion;
            await context.SaveChangesAsync();
        }

        public async Task DeleteActualite(Actualite actualite)
        {
            if(actualite == null)
                throw new ActualiteNotFoundException();
            context.Remove(actualite);
            await context.SaveChangesAsync();
            
        }

        public async Task<Commerce> getCommerceActualite(int commerceId)
        {
            CommercesDAO commercesDAO = new CommercesDAO(context);
            return await commercesDAO.GetCommerce(commerceId);
        }
    }
}