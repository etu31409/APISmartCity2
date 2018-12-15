using System;
namespace APISmartCity.ExceptionPackage{
    public class UserAlreadyExistException : PersonnalException{
        public UserAlreadyExistException()
            : base("Utilisateur déjà présent dans la base de donnée !"){}
        public UserAlreadyExistException(string message)
            :base(message){}
    }
}