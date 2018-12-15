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
    public class CommercesDAO
    {
        private SCNConnectDBContext context;
        public CommercesDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Commerce>> GetCommerces(int categorie, int UserId, bool all)
        {   //fixme : Problème de chargement entités liés - Include
            return await context.Commerce
                .Where(c => (categorie == 0 || c.IdCategorie == categorie) && (c.IdUser == UserId || all))
                .ToListAsync();
        }

        public async Task<Commerce> GetCommerce(int id)
        {
            return await context.Commerce.FirstOrDefaultAsync(c => c.IdCommerce == id);
        }

        public async Task ModifCommerce(Commerce entity, Commerce dto)
        {
            //fixme: Configurer un mapper
            entity.NomCommerce = dto.NomCommerce;
            entity.AdresseMail = dto.AdresseMail;
            entity.Actualite = dto.Actualite;
            entity.Numero = dto.Numero;
            entity.Rue = dto.Rue;
            entity.Description = dto.Description;
            entity.IdCategorie = dto.IdCategorie;
            entity.IdCategorieNavigation = dto.IdCategorieNavigation;
            entity.IdCommerce = dto.IdCommerce;
            entity.IdUser = dto.IdUser;
            entity.IdUserNavigation = dto.IdUserNavigation;
            entity.ImageCommerce = dto.ImageCommerce;
            entity.NumeroFixe = dto.NumeroFixe;
            entity.NumeroGsm = dto.NumeroGsm;
            entity.ParcoursProduitPhare = dto.ParcoursProduitPhare;
            entity.ProduitPhare = dto.ProduitPhare;
            entity.UrlPageFacebook = dto.UrlPageFacebook;

            context.Entry(entity).OriginalValues["RowVersion"] = dto.RowVersion;
            await context.SaveChangesAsync();
            //return Ok(Mapper.Map<DTO.Commerce>(Model.Commerce));
        }

        public async Task<Model.Commerce> AddCommerce(Commerce commerce)
        {
            if (commerce == null)
                throw new CommerceNotFoundException();
            context.Commerce.Add(commerce);
            await context.SaveChangesAsync();
            return commerce;
        }

        public async Task DeleteCommerce(Commerce commerce)
        {
            context.Remove(commerce);
            await context.SaveChangesAsync();            
        }
    }
}