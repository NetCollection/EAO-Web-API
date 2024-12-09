using EAO.BL.DTOs.User;
using EAO.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAO.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly LoginService _LoginService;
        private readonly IConfiguration _configuration;
        public AuthController(LoginService login, IConfiguration configuration)
        {
            _LoginService = login;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user and generates a JSON Web Token (JWT) for authorized access to the system.
        /// </summary>
        /// <param name="user">The user's login credentials, including username and password.</param>
        /// <returns>A JWT token that can be used for subsequent authenticated requests.</returns>
        /// <remarks>
        /// Example Request:
        /// POST Api/Auth/Login
        /// 
        /// Request Body:
        /// {
        ///   "username": "user@example.com",
        ///   "password": "password"
        /// }
        /// 
        /// Example Response:
        /// HTTP Status Code: 200 OK
        /// Response Body:
        /// {
        ///   "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.S3kr3tT0k3n"
        /// }
        /// 
        /// HTTP Status Code: 400 Bad Request (if login credentials are invalid)
        /// </remarks>
        /// <response code="200">Returns a JWT token that grants access to protected resources.</response>
        /// <response code="400">Returns an error message if the provided credentials are incorrect.</response>

        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login(UserDto user)
        {


            //var t = EncryptionClass.EncryptString("MobEAO@123");
            // var nn = EncryptionClass.DecryptString("dekbMMZiUZrnOxlClsk8SQ==");
            //var uname = userLoginClass.UserName.ToLower();
            //string domainAndUsername = string.Concat("rayacx", "\\", uname);
            //DirectoryEntry entry = new DirectoryEntry("LDAP://rayacx.corp", domainAndUsername, userLoginClass.Password);
            //try
            //{
            //    //object obj = entry.NativeObject;
            //    DirectorySearcher search = new DirectorySearcher(entry)
            //    {
            //        Filter = string.Concat("(SAMAccountName=", uname, ")")
            //    };
            //    search.PropertiesToLoad.Add("cn");


            //    var result = search.FindOne();

            //    if (result == null)
            //    {
            //        flag = false;
            //        return NotFound("The user name or password is incorrect");
            //    }
            //    else
            //    {
            //        flag = true;
            //    }
            //}
            //catch (Exception exception)
            //{
            //    flag = false;
            //    return NotFound("The user name or password is incorrect");

            //}

            //return flag;
            //if (flag == true)
            {
                int expiredTime = int.Parse(_configuration.GetSection("AppSettings:ExpiredTime").Value);
                string KeyToken = _configuration.GetSection("AppSettings:Token").Value;
                var userExist = await _LoginService.Login(user.Username, user.Password);
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
                    return BadRequest("user not found");
                }

            }
            //else
            //{
            //    return NotFound("UserName or Password Not Vaild For LDAB");
            //}

        }
    }
}
