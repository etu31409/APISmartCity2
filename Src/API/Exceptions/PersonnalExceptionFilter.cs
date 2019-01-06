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


            if (context.Exception.GetType()==typeof(DbUpdateConcurrencyException))
            {
               
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Conflict,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Access concurent à la base de donnée" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(ActualiteNotFoundException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Actualite introuvable" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(CommerceNotFoundException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Commerce introuvable" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(FavorisNotFoundException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Favoris introuvable" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(InvalidOpeningPeriodException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Période d'ouverture invalide" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(IsAleadySetToFavorisException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Commerce déjà ajouter aux favoris" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(OpeningPeriodNotFoundException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Période d'ouverture introuvable" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(UserAlreadyExistException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Utilisateur déjà existant" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(UserNotFoundException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = "Utilisateur introuvable" }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }else
            if (context.Exception.GetType().IsSubclassOf(typeof(PersonnalException)))
            {
                var result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = Newtonsoft.Json.JsonConvert.SerializeObject(new PersonnalError() { Message = context.Exception.Message }),
                    ContentType = "application/json"

                };
                context.Result = result;
            }
        }
    }
}
