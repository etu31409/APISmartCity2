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
using AutoMapper;
using APISmartCity.DTO;
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
        public async Task<IActionResult> Get()
        {
            List<Model.OpeningPeriod> openingPeriods= await dao.GetOpeningPeriods();
            return Ok(Mapper.Map<List<OpeningPeriodDTO>>(openingPeriods));
        }

        // GET api/OpeningPeriod/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Model.OpeningPeriod entity = await FindOpeningPeriodById(id);
            //return (entity == null) ? NotFound() : (IActionResult)Ok(dao.CreateDTOFromEntity(entity));
            if(entity == null)
                return NotFound();
            return Ok(Mapper.Map<OpeningPeriodDTO>(entity));
        }

        private Task<Model.OpeningPeriod> FindOpeningPeriodById(int id)
        {
            return context.OpeningPeriod.FirstOrDefaultAsync(op => op.IdHoraire == id);
        }

        // GET api/OpeningPeriod/Shop/5
        [HttpGet("Shop/{shopId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DTO.OpeningPeriodDTO>))]
        public async Task<IActionResult> GetByShop(int shopId)
        { 
            Model.Commerce commerceFound = await FindCommerceById(shopId);
            if (commerceFound == null)
                return NotFound();

            return Ok(commerceFound.OpeningPeriod.Select(dao.CreateDTOFromEntity));
        }

        private async Task<Model.Commerce> FindCommerceById(int shopId)
        { 
            return await commercesDAO.GetCommerce(shopId);
        }

        //POST api/OpeningPeriod
       [HttpPost("Shop/{shopId}")]
       public async Task<IActionResult> Post(int shopId, [FromBody]DTO.OpeningPeriodDTO dto)
        {
            Model.Commerce commerce = await FindCommerceById(shopId);
            if (commerce == null)
                return NotFound();

            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            if (!User.IsInRole(Constants.Roles.ADMIN) && commerce.IdUser!=userId)
                return Forbid();

            //Model.OpeningPeriod entity = CreateEntityFromDTO(dto);
            Model.OpeningPeriod entity = Mapper.Map<Model.OpeningPeriod>(dto);

            await dao.AddOpeningPeriod(entity, commerce);
            return Created($"api/OpeningPeriods/Shop/{entity.IdHoraire}", Mapper.Map<OpeningPeriod>(dto));
        }

        private Model.OpeningPeriod CreateEntityFromDTO(DTO.OpeningPeriodDTO dto)
        {
            return new Model.OpeningPeriod(dto.HoraireDebut, dto.HoraireFin, dto.Jour, dto.IdCommerce);
        }

        // PUT api/OpeningPeriod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]DTO.OpeningPeriodDTO dto)
        {
            Model.OpeningPeriod entity = await FindOpeningPeriodById(id);
            if (entity == null)
                return NotFound();

            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            //Pas possible si l'utilisateur n'est pas le propriétaire du commerce ou admin
            Commerce commerce = await dao.getCommerceOpeningPeriod(dto.IdCommerce);
            if(commerce.IdUser != userId && !User.IsInRole(Constants.Roles.ADMIN))
                 return Forbid();

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
