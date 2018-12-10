using System;
namespace APISmartCity.ExceptionPackage{
    public class OpeningPeriodNotFoundException : PersonnalException{
        public OpeningPeriodNotFoundException()
            : base("Commerce non trouvé dans les données"){}
        public OpeningPeriodNotFoundException(string message)
            :base(message){}
    }
}