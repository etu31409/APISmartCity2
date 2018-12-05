using System;
namespace APISmartCity.ExceptionPackage{
    public class CommerceNotFoundException : Exception{
        public CommerceNotFoundException()
            : base("Commerce non trouvé dans les données"){}
        public CommerceNotFoundException(string message)
            :base(message){}
    }
}