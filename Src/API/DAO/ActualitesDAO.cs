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
    }
}