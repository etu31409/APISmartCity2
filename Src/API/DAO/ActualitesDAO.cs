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

        public async Task<Actualite> UpdateActualite(Actualite entity, ActualiteDTO actuDto)
        {
            entity = Mapper.Map<Actualite>(actuDto);
            //context.Entry(entity).OriginalValues["RowVersion"] = actuDto.RowVersion;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteActualite(Actualite actualite)
        {
            try{
                context.Remove(actualite);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Commerce> getCommerceActualite(int commerceId)
        {
            CommercesDAO commercesDAO = new CommercesDAO(context);
            return await commercesDAO.GetCommerce(commerceId);
        }
    }
}