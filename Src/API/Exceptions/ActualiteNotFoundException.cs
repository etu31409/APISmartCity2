using System;
namespace APISmartCity.ExceptionPackage{
    public class ActualiteNotFoundException : PersonnalException{
        public ActualiteNotFoundException()
            : base("Actualite non trouvé dans les données"){}
        public ActualiteNotFoundException(string message)
            :base(message){}
    }
}