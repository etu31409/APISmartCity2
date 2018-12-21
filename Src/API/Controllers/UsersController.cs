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
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            //Bof ... si email devient la clé primaire de user pas besoin de vérifier içi
            User userDB = await userDAO.GetUser(user.Email);
            if(userDB != null){
                if(userDB.Email == user.Email)
                    return Forbid();
            }
            user.Password = Hashing.HashPassword(user.Password);
            user = await userDAO.AddUser(user);
            return Created($"api/user", user);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User user = await userDAO.GetUserWithId(id);
            if(user == null)
                return NotFound();
            return Ok(Mapper.Map<DTO.UserDTO>(user));
        }
    }
}
