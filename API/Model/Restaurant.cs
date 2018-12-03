using System.Collections.Generic;
namespace APISmartCity.Model
{
    public class Restaurant
    {

        public Restaurant(int id, string nomCommerce, Address address, List<string> moyensPayements, string description, string produitPhare
                ,string parcoursProduitPhare, int numGSM, int numTel, string mail, string urlPageFacebook, int coordGPS){
            this.Id = id;
            this.NomCommerce = nomCommerce;
            this.Address = address;
            this.MoyensPayements = moyensPayements;
            this.Description = description;
            this.ProduitPhare = produitPhare;
            this.ParcoursProduitPhare = parcoursProduitPhare;
            this.NumGSM = numGSM;
            this.NumTel = numTel;
            this.Mail = mail;
            this.UrlPageFacebook = urlPageFacebook;
            this.CoordGPS = coordGPS;
        }

        public int Id{get; set;}
        public string NomCommerce {get; set;}
        public Address Address {get; set;}
        public List<string> MoyensPayements {get; set;}
        public string Description {get; set;}
        public string ProduitPhare {get; set;}
        public string ParcoursProduitPhare {get; set;}
        public int NumGSM {get; set;}
        public int NumTel {get; set;}
        public string Mail {get; set;}
        public string UrlPageFacebook {get; set;}
        public int CoordGPS {get; set;}
    }
}