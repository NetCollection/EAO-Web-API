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

            bool flag;
            var uname = userLoginClass.UserName.ToLower();
            string domainAndUsername = string.Concat("rayacx", "\\", uname);
            DirectoryEntry entry = new DirectoryEntry("LDAP://rayacx.corp", domainAndUsername, userLoginClass.Password);
            try
            {
                //object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry)
                {
                    Filter = string.Concat("(SAMAccountName=", uname, ")")
                };
                search.PropertiesToLoad.Add("cn");


                var result = search.FindOne();

                if (result == null)
                {
                    flag = false;
                    return NotFound("The user name or password is incorrect");
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                flag = false;
                return NotFound("The user name or password is incorrect");

            }

            //return flag;
            if (flag == true)
            {
                int expiredTime = int.Parse(_configuration.GetSection("AppSettings:ExpiredTime").Value);
                string KeyToken = _configuration.GetSection("AppSettings:Token").Value;
                var userExist = await _LoginService.Login(userLoginClass.UserName);
                if (userExist != null && !string.IsNullOrEmpty(userExist.UserName))
                {
                    List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, userExist.UserName.ToString()),
                                new Claim(ClaimTypes.Role,userExist.RoleId.HasValue.ToString()),
                                 new Claim(ClaimTypes.PrimarySid,userExist.Id.ToString()),

                                new Claim(ClaimTypes.Email,userExist.Email.ToString()),
                                new Claim(ClaimTypes.Sid,userExist.GovId.HasValue.ToString()),

                            };
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyToken));

                    SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(expiredTime),
                        SigningCredentials = creds
                    };
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

                    string token = tokenHandler.WriteToken(securityToken);

                    string tokenWithBearer = "Bearer " + token;

                    userExist.Token = tokenWithBearer;

                    //return Ok(userExist);
                    return Ok(new { Token = tokenWithBearer });

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






    }
}
