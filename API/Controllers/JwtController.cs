using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using APISmartCity.Model;
namespace APISmartCity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {  
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtController(IOptions<JwtIssuerOptions> jwtOptions){
            this._jwtOptions = jwtOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var repository = new AuthenticationRepository();
            User userFound = repository.GetUsers().FirstOrDefault(user => user.UserName==model.Username && user.Password == model.Password);
            if(userFound==null)
                return Unauthorized();
            
            var claims = new []{
                new Claim(JwtRegisteredClaimNames.Sub, userFound.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,
                        ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(),
                        ClaimValueTypes.Integer64),
                //Permet de rajouter l'ID de l'utilisateur dans les claims pour pouvoir tester son identité lors d'une modification
                new Claim(JwtRegisteredClaimNames.NameId, userFound.Id.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            var response = new{
                access_token = encodedJwt,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
            };

            return Ok(response);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}