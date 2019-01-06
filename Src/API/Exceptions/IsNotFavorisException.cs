using System;
namespace APISmartCity.ExceptionPackage{
    public class IsNotFavorisException : PersonnalException{
        public IsNotFavorisException()
            : base("Le commerce doit d'abord être ajouté aux favoris !"){}
        public IsNotFavorisException(string message)
            :base(message){}
    }
}