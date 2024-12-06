
using EAO.BL.DTOs.User;
using EAO.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly LoginService _LoginService;
        private readonly IConfiguration _configuration;
        public LoginController(LoginService login, IConfiguration configuration)
        {
            _LoginService = login;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> UserLogin(UserDto userLoginClass)
        {
            try
            {
                bool flag;
                string domainAndUsername = string.Concat("Contactcntr", "\\", userLoginClass.UName.ToLower());
                DirectoryEntry entry = new DirectoryEntry("LDAP://contactcntr.raya.corp", domainAndUsername, userLoginClass.PWD);
                try
                {
                    //object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry)
                    {
                        Filter = string.Concat("(SAMAccountName=", userLoginClass.UName.ToLower(), ")")
                    };
                    search.PropertiesToLoad.Add("cn");
                    var result = search.FindOne();

                    if (result == null)
                    {
                        flag = false;
                               return NotFound("UserName or Password Not Vaild For LDAB");
                    }
                    else
                    {
                        flag = true;
                    }
                }
                catch (Exception exception)
                {
                    flag = false;
                    return NotFound("UserName or Password Not Vaild For LDAB");

                }
               
                //return flag;
                if (flag == true)
                {
                    var userExist = await _LoginService.Login(userLoginClass.UName);
                    if (userExist != null)
                    {
                        List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, userExist.UName.ToString()),
                                new Claim(ClaimTypes.Role,userExist.roleId!.ToString()),
                                 new Claim(ClaimTypes.PrimarySid,userExist.Id.ToString()),

                                new Claim(ClaimTypes.Email,userExist.Email.ToString()),
                                new Claim(ClaimTypes.Sid,userExist.govId.ToString()),

                            };
                        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                        //if (key.Key.Length>64)
                        //{

                        //}
                        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddHours(24),
                            SigningCredentials = creds
                        };
                        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                        SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        string token = tokenHandler.WriteToken(securityToken);

                        string tkon = "Bearer " + token;

                        userExist.Token = tkon;
                        return Ok(userExist);

                    }
                    else
                    {
                        return NotFound("UserName Not Found");
                    }



                }
                else
                {
                    return NotFound("UserName or Password Not Vaild For LDAB");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("This Process Failed");
            }
        }




    }
}
