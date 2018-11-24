
namespace APISmartCity.Controllers
{
    public class Commerce
    {
        public int CommerceId{get;set;}
        public string NomCommerce{get;set;}
        public Address Address{get;set;}

        public Commerce(int commerceId, string nomCommerce, Address address)
        {
            CommerceId = commerceId;
            NomCommerce = nomCommerce;
            Address = address;
        }
    }
}