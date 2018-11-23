using System.Collections.Generic;
namespace APISmartCity.Controllers
{
    public class Restaurant
    {

        public Restaurant(string nomCommerce, Address address, List<string> moyensPayements, string description, string produitPhare
                ,string parcoursProduitPhare, int numGSM, int numTel, string mail, string urlPageFacebook, int coordGPS){
            NomCommerce = nomCommerce;
            Address = address;
            MoyensPayements = moyensPayements;
            Description = description;
            ProduitPhare = produitPhare;
            ParcoursProduitPhare = parcoursProduitPhare;
            NumGSM = numGSM;
            NumTel = numTel;
            Mail = mail;
            UrlPageFacebook = urlPageFacebook;
            CoordGPS = coordGPS;
        }

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