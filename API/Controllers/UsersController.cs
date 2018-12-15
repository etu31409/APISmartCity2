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

namespace APISmartCity.Controllers
{
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
            user = await userDAO.AddUser(user);
            return Created($"api/user", user);
        }

    }
}
