using System;
namespace APISmartCity.ExceptionPackage{
    public class FavorisNotFoundException : PersonnalException{
        public FavorisNotFoundException()
            : base("Favoris non trouvé dans les données"){}
        public FavorisNotFoundException(string message)
            :base(message){}
    }
}