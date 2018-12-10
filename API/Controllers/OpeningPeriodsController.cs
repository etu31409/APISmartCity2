using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.Model;
using APISmartCity.DAO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class OpeningPeriodsController : Controller
    {
        private SCNConnectDBContext context;
        private OpeningPeriodDAO dao;
        private CommercesDAO commercesDAO;
        public OpeningPeriodsController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.commercesDAO = new CommercesDAO(context);
            this.dao = new OpeningPeriodDAO(context);
        }

        // GET: api/OpeningPeriod
        [HttpGet]
        public IActionResult Get()
        {
            //todo: Débat: Est-ce que cette méthode a un sens
            return Ok(dao.GetOpeningPeriods());
        }

        // GET api/OpeningPeriod/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Model.OpeningPeriod entity = await FindOpeningPeriodById(id);
            return (entity == null) ? NotFound() : (IActionResult)Ok(dao.CreateDTOFromEntity(entity));

        }

        private Task<Model.OpeningPeriod> FindOpeningPeriodById(int id)
        {
            //fixme: Comment faire?
            throw new NotImplementedException();
        }

        // GET api/OpeningPeriod/Shop/5
        [HttpGet("Shop/{shopId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DTO.OpeningPeriod>))]
        public async Task<IActionResult> GetByShop(int shopId)
        { //TODO : Passer par la classe de dao
            Model.Commerce commerceFound = await FindCommerceById(shopId);
            if (commerceFound == null)
                return NotFound();

            IEnumerable<DTO.OpeningPeriod> dtos = commerceFound.OpeningPeriod.Select(dao.CreateDTOFromEntity);
            return Ok(dtos);
        }

        private async Task<Model.Commerce> FindCommerceById(int shopId)
        { 
            return await commercesDAO.GetCommerce(shopId);
        }

        //POST api/OpeningPeriod
       [HttpPost("Shop/{shopId}")]
       public async Task<IActionResult> Post(int shopId, [FromBody]DTO.OpeningPeriod dto)
        { //TODO : Passer par le dao
            Model.Commerce commerce = await FindCommerceById(shopId);
            if (commerce == null)
                return NotFound();  
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);

            if (!User.IsInRole(Constants.Roles.Admin) && commerce.IdPersonne!=userId)
                return Forbid();

            Model.OpeningPeriod entity = CreateEntityFromDTO(dto);

            dao.AddOpeningPeriod(entity);

            return Created($"api/{entity.IdHoraire}", dao.CreateDTOFromEntity(entity));
        }

        private Model.OpeningPeriod CreateEntityFromDTO(DTO.OpeningPeriod dto)
        {
            return new Model.OpeningPeriod(dto.Opening, dto.Closing, dto.Day);
        }

        // PUT api/OpeningPeriod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]DTO.OpeningPeriod dto)
        {
            Model.OpeningPeriod entity = await FindOpeningPeriodById(id);
            if (entity == null)
                return NotFound();

            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            //if(entity.IdCommerce != userId && !User.IsInRole(Constants.Roles.Admin))
              //  return Forbid();
              //fixme : Faire une validation que le commerce (opening period par extension) appartient bien a l'utilisateur

            await dao.ModifOpeningPeriod(entity, dto);
            return Ok(dto);
        }

        // DELETE api/OpeningPeriod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Model.OpeningPeriod entity = await FindOpeningPeriodById(id);
            if (entity == null)
                return NotFound();
            await dao.DeleteOpeningPeriod(entity);
            return Ok();
        }
    }
}
