using System;
namespace APISmartCity.ExceptionPackage{
    public class UserNotFoundException : PersonnalException{
        public UserNotFoundException()
            : base("Utilisateur non trouvé dans les données"){}
        public UserNotFoundException(string message)
            :base(message){}
    }
}