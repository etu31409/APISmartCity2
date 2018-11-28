namespace APISmartCity.Controllers.Model
{
    public class Address
    {
        public Address(){}

        public string Rue{get;set;}
        public string CodePostal{get;set;}
        public int Numero{get;set;}

        public Address(string rue, string codePostal, int numero)
        {
            Rue = rue;
            CodePostal = codePostal;
            Numero = numero;
        }
    }
}