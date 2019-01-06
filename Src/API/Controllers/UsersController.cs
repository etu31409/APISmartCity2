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
using APISmartCity.Infra;
using APISmartCity.DTO;

namespace APISmartCity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private SCNConnectDBContext context;
        private UserDAO userDAO;
        public UsersController(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userDAO = new UserDAO(context);
        }
        
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(201, Type = typeof(DTO.UserDTO))]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO dto)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            //si email devient la clé primaire de user pas besoin de vérifier içi
            User userDB = await userDAO.GetUser(dto.Email);
            if(userDB != null){
                //if(userDB.Email == dto.Email)
                    return Forbid();
            }
            dto.Password = Hashing.HashPassword(dto.Password);
            var userEntity = Mapper.Map<User>(dto);
            userEntity = await userDAO.AddUser(userEntity);
            return Created($"api/user", Mapper.Map<UserDTO>(userEntity));
        }

        //seul il faut que le userId dans le token et l'id en argument sois les mêmes
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DTO.UserDTO))]
        public async Task<ActionResult<User>> GetById(int id)
        {
            if(id <= 0){
                return NotFound();
            }
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            if(id != userId && !User.IsInRole(Constants.Roles.ADMIN)){
                return Forbid();
            }
            User user = await userDAO.GetUserWithId(id);
            if(user == null)
                return NotFound();
            return Ok(Mapper.Map<DTO.UserDTO>(user));
        }
        
        //TODO put 

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = Constants.Roles.USER)]
        [ProducesResponseType(201, Type = typeof(DTO.UserDTO))]
        public async Task<ActionResult> Delete(int id)
        {
            User user = await userDAO.GetUserWithId(id);
            if(user == null)
                return NotFound();
            int userId = int.Parse(User.Claims.First(c => c.Type == PrivateClaims.UserId).Value);
            if(id != userId && !User.IsInRole(Constants.Roles.ADMIN)){
                return Forbid();
            }
            await userDAO.DeleteUser(user);
            return Ok(Mapper.Map<UserDTO>(user));
        }
    }
}
