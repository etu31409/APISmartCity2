using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APISmartCity.ExceptionPackage;
using APISmartCity.Model;

namespace APISmartCity.DTO
{
    public class CommerceDTO
    {
        public CommerceDTO()
        {
            //Actualite = new HashSet<Actualite>();
            //ImageCommerce = new HashSet<ImageCommerce>();
            //OpeningPeriod = new HashSet<OpeningPeriodDTO>();
        }

        [Required]
        public int IdCommerce { get; set; }
        [Required]
        public string NomCommerce { get; set; }
        [Required]
        public string Rue { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProduitPhare { get; set; }
        public string ParcoursProduitPhare { get; set; }
        public int? NumeroGsm { get; set; }
        public int? NumeroFixe { get; set; }
        [EmailAddress]
        public string AdresseMail { get; set; }
        public string UrlPageFacebook { get; set; }
        public int? IdCategorie { get; set; }
        public int? IdUser { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<OpeningPeriodDTO> OpeningPeriod { get; set; }
        public ICollection<ImageCommerceDTO> ImageCommerce { get; set; }
        public ICollection<ActualiteDTO> Actualite { get; set; }
        
    }
}