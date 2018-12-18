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
            OpeningPeriod = new HashSet<OpeningPeriodDTO>();
        }

        public int IdCommerce { get; set; }
        public string NomCommerce { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public string Description { get; set; }
        public string ProduitPhare { get; set; }
        public string ParcoursProduitPhare { get; set; }
        public int? NumeroGsm { get; set; }
        public int? NumeroFixe { get; set; }
        public string AdresseMail { get; set; }
        public string UrlPageFacebook { get; set; }
        public int? IdCategorie { get; set; }
        public int? IdUser { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<OpeningPeriodDTO> OpeningPeriod { get; set; }
        public ICollection<ImageCommerceDTO> ImageCommerce { get; set; }

        public void AddOpeningPeriod(OpeningPeriodDTO newPeriod)
        {
            if (OpeningPeriod.Any(existingPeriod =>
                existingPeriod.Jour == newPeriod.Jour &&
                (newPeriod.HoraireFin >= existingPeriod.HoraireDebut && newPeriod.HoraireFin <= existingPeriod.HoraireFin) ||
                (newPeriod.HoraireDebut >= existingPeriod.HoraireDebut && newPeriod.HoraireDebut <= existingPeriod.HoraireFin) ||
                (newPeriod.HoraireDebut <= existingPeriod.HoraireDebut && newPeriod.HoraireFin >= existingPeriod.HoraireFin)))
                throw new InvalidOpeningPeriodException();

            this.OpeningPeriod.Add(newPeriod);
        }
    }
}