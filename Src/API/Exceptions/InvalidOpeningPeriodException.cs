using System;

namespace APISmartCity.ExceptionPackage{
    public class InvalidOpeningPeriodException: PersonnalException
    {
        public InvalidOpeningPeriodException()
        :base("Deux périodes d'ouverture se chevauchent")
        {
            
        }
    }
}