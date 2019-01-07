using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using APISmartCity.ExceptionPackage;
using APISmartCity.DTO;

namespace APISmartCity.ExceptionPackage
{
    public class PersonnalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public PersonnalExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("APISmartCity.Exceptions");
        }

        void IExceptionFilter.OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Une erreur inattendue s'est produite");

            string message;

            if (context.Exception.GetType() == typeof(DbUpdateConcurrencyException))
            {
                message = "Access concurent à la base de donnée";
            }
            else
            if (context.Exception.GetType().IsSubclassOf(typeof(PersonnalException)))
            {
                message = context.Exception.Message;
            }
            else
            {
                message = "Une erreur s'est produite lors de l'execution de la requete";
            }

            var result = new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.Conflict,
                Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = message}),
                ContentType = "application/json"
            };
            context.Result = result;

        }
    }
}
