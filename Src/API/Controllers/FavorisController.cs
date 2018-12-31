using System;
using APISmartCity.Model;
using APISmartCity.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using APISmartCity.ExceptionPackage;
using AutoMapper;
using APISmartCity.DTO;
using Microsoft.EntityFrameworkCore;

namespace APISmartCity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FavorisController : ControllerBase
    {
        private SCNConnectDBContext context;
        private FavorisDAO favorisDAO;
        public FavorisController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.favorisDAO = new FavorisDAO(context);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FavorisDTO dto)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            Favoris entity = Mapper.Map<Model.Favoris>(dto);
            entity = await favorisDAO.AddFavoris(entity);  
            return Created($"api/Favoris/{dto.IdFavoris}", Mapper.Map<ActualiteDTO>(entity));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            List<Favoris> entity = await favorisDAO.GetFavoris();
            return (entity == null) ? NotFound() : (IActionResult)Ok(Mapper.Map<List<FavorisDTO>>(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Favoris favoris = await favorisDAO.GetFavoris(id);
            if(favoris==null)
                return NotFound();
            await favorisDAO.DeleteFavoris(favoris);
            return Ok();
        }
    }
}