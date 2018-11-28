namespace APISmartCity.Controllers.Model
{
    public class Commerce
    {
        public int CommerceId{get;set;}
        public string NomCommerce{get;set;}
        public Address Address{get;set;}

        public Commerce(int commerceId, string nomCommerce, Address address)
        {
            this.CommerceId = commerceId;
            this.NomCommerce = nomCommerce;
            this.Address = address;
        }
    }
}