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
    public class categorieDAO
    {
        private SCNConnectDBContext context;
        public categorieDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Categorie>> GetCategories()
        {
            return await context.Categorie.ToListAsync();
        }
    }
}