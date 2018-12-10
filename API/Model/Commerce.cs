using System;
using System.Collections.Generic;
using System.Linq;
using APISmartCity.ExceptionPackage;

namespace APISmartCity.Model
{
    public partial class Commerce
    {
        public Commerce()
        {
            Actualite = new HashSet<Actualite>();
            ImageCommerce = new HashSet<ImageCommerce>();
            OpeningPeriod = new HashSet<OpeningPeriod>();
        }

        public int? IdCommerce { get; set; }
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
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public int? IdCategorie { get; set; }
        public int? IdPersonne { get; set; }
        public byte[] RowVersion { get; set; }

        public Categorie IdCategorieNavigation { get; set; }
        public Personne IdPersonneNavigation { get; set; }
        public ICollection<Actualite> Actualite { get; set; }
        public ICollection<ImageCommerce> ImageCommerce { get; set; }
        public ICollection<OpeningPeriod> OpeningPeriod { get; set; }

        public void AddOpeningPeriod(OpeningPeriod newPeriod)
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
