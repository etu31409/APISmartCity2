using System;
namespace APISmartCity.ExceptionPackage
{
    public class PersonnalException:Exception
    {
        public PersonnalException(string message)
            :base(message)
        {
        }
    }
}
