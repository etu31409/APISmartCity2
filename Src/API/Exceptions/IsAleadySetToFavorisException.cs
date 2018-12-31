using System;
namespace APISmartCity.ExceptionPackage{
    public class IsAleadySetToFavorisException : PersonnalException{
        public IsAleadySetToFavorisException()
            : base("Le favoris est déjà définit !"){}
        public IsAleadySetToFavorisException(string message)
            :base(message){}
    }
}