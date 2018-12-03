namespace APISmartCity.Model
{
    public class Address
    {
        public Address(){}

        public string Rue{get;set;}
        public int CodePostal{get;set;}
        public int Numero{get;set;}

        public Address(string rue, int codePostal, int numero)
        {
            Rue = rue;
            CodePostal = codePostal;
            Numero = numero;
        }
    }
}