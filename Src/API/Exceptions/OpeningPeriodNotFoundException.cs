using System;
namespace APISmartCity.ExceptionPackage{
    public class OpeningPeriodNotFoundException : PersonnalException{
        public OpeningPeriodNotFoundException()
            : base("Période d'ouverture non trouvé dans les données"){}
        public OpeningPeriodNotFoundException(string message)
            :base(message){}
    }
}