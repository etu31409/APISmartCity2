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
    public class FavorisDAO
    {
        private SCNConnectDBContext context;
        public FavorisDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Model.Favoris> AddFavoris(Favoris favoris)
        {
            if (favoris == null)
                throw new FavorisNotFoundException();
            context.Favoris.Add(favoris);
            await context.SaveChangesAsync();
            return favoris;
        }

        public async Task<List<Favoris>> GetFavoris()
        {
            return await context.Favoris.ToListAsync();
        }

        public async Task<Favoris> GetFavorisById(int id)
        {
            return await context.Favoris.FirstOrDefaultAsync(f => f.IdFavoris == id);
        }

        public async Task DeleteFavoris(Favoris favoris)
        {
            if(favoris == null)
                throw new FavorisNotFoundException();
            context.Remove(favoris);
            await context.SaveChangesAsync();
        }

        public async Task<Favoris> GetOneFavoris(Favoris favoris)
        {
            return await context.Favoris.FirstOrDefaultAsync(
                x => x.IdUser == favoris.IdUser && x.IdCommerce == favoris.IdCommerce
            );
        }
    }
}