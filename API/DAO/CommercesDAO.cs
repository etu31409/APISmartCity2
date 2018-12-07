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
        public CommercesDAO(){   }
        private SCNConnectDBContext context = new SCNConnectDBContext();
        public async Task<List<Commerce>> GetCommerces(int categorie){
            //BETTER Faire un include en plus pour avoir le nom de la catégorie et pas l'id (clé étrangère)
            return await context.Commerce.Where( c => categorie == 0 || c.IdCategorie == categorie).ToListAsync();
        }

        public async Task<Commerce> GetCommerce(int id){
            //Return du restaurant correspondant à l'identifiant passé en argument
            return await context.Commerce.FirstOrDefaultAsync(c => c.IdCommerce == id);
        }

        public async Task<Commerce> ModifCommerce(Commerce entity, Commerce dto){
            //Gérer les accès concurents plus tard
            
            //Changer tout les champs de l'entity
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
            entity.IdPersonne = dto.IdPersonne;
            entity.IdPersonneNavigation = dto.IdPersonneNavigation;
            entity.ImageCommerce = dto.ImageCommerce;
            entity.Latitude = dto.Latitude;
            entity.Longitude = dto.Longitude;
            entity.NumeroFixe = dto.NumeroFixe;
            entity.NumeroGsm = dto.NumeroGsm;
            entity.ParcoursProduitPhare = dto.ParcoursProduitPhare;
            entity.ProduitPhare = dto.ProduitPhare;
            entity.UrlPageFacebook = dto.UrlPageFacebook;

            context.Entry(entity).OriginalValues["RowVersion"] = dto.RowVersion;
            await context.SaveChangesAsync();
            return entity;
            //return Ok(Mapper.Map<DTO.Commerce>(Model.Commerce));
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