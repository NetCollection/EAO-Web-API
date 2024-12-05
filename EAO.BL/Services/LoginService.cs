using EAO.BL.DTOs.User;
using EAO.DAL.Models;

namespace EAO.BL.Services
{
    public class LoginService
    {
        private readonly EaoNsContext _context;
        public LoginService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }

        public async Task<UserVM> Login(string uname)
        {
            UserVM userVM = new UserVM();

            var user = _context.Users.Where(A => A.Name.ToLower() == uname.ToLower() && A.Active == true).FirstOrDefault();
            if (user != null)
            {
                userVM.UName = user.Name;
                userVM.ar_name = user.ArName;
                userVM.Email = user.Email;
                userVM.regionId = user.RegionId;
                userVM.roleId = user.RoleId;
                userVM.govId = user.GovId;
                userVM.Id = user.Id;



            }
            else
            {
                return new UserVM();
            }
            return await Task.FromResult(userVM);

        }


    }
}
