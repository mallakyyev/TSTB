using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.DAL.Models.User;
namespace TSTB.BLL.Services.ApplicationUser
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<DAL.Models.User.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public ApplicationUserService(UserManager<DAL.Models.User.ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

     

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
        }

        public IEnumerable<DAL.Models.User.ApplicationUser> GetAllEntreprenuerAndOrganizationUsers()
        {
            var appUsers = _userManager.Users.Where(o => o.UserName != "Admin" && (o.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Entreprenuer
            || o.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Organization)).OrderBy(o => o.FirstName);
            //var users = _mapper.ProjectTo<ApplicationUserDTO>(appUsers).AsQueryable();
            return appUsers;//users;
        }

        public IEnumerable<string> GetAllEntreprenuerEmails()
        {
            List<string> res = new List<string>(_userManager.Users.Where(p => p.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Entreprenuer).Select(p => p.Email));
            return res;
        }

        public IEnumerable<string> GetAllorganizationEmails()
        {
            List<string> res = new List<string>(_userManager.Users.Where(p => p.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Organization).Select(p => p.Email));
            return res;
        }

        //public IEnumerable<DAL.Models.User.ApplicationUser> GetAllInterpreneurAndOrg()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<TSTB.DAL.Models.User.ApplicationUser> GetAllUsers()
        {
            
            var appUsers = _userManager.Users.Where(o=>o.UserName!="Admin").OrderBy(o => o.FirstName);
            //var users = _mapper.ProjectTo<ApplicationUserDTO>(appUsers).AsQueryable();
            return appUsers;//users;
        }

        public async Task<ApplicationUserDTO> GetUserProfile(string userId)
        {
            var appUser = await _userManager.Users
                .SingleOrDefaultAsync(s => s.Id == userId);
            var user = _mapper.Map<DAL.Models.User.ApplicationUser, ApplicationUserDTO>(appUser);
            return user;
        }
    }
}
