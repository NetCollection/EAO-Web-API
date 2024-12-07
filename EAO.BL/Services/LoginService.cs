using EAO.BL.DTOs.User;
using EAO.BL.Helpers;
using EAO.DAL.Models;
using System.Reflection.PortableExecutable;

namespace EAO.BL.Services
{
    public class LoginService
    {
        private readonly EaoNsContext _context;
        public LoginService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }

        public async Task<UserVM> Login(string uname,string pwd)
        {
            UserVM userVM = new UserVM();
            var pwdencrypt = EncryptionClass.EncryptString(pwd);
            var user = _context.Users.Where(A => A.Name.ToLower() == uname.ToLower()&&A.Password==pwdencrypt && A.Active == true).FirstOrDefault();

            if (user != null)
            {
                userVM.UserName = user.Name;
                userVM.Ar_name = user.ArName;
                userVM.Email = user.Email;
                userVM.RegionId = user.RegionId;
                userVM.RoleId = user.RoleId;
                userVM.GovId = user.GovId;
                userVM.Id = user.Id;

            }

            return await Task.FromResult(userVM);


        }



    }
}
