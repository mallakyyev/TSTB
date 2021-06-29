using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.BLL.Services.ApplicationUser;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.User;
using TSTB.Web.Binder;
using TSTB.Web.Data;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, Registration-Manager")]
    [ApiController]
    public class ApplicationUserAPIController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationUserService _userService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IImageService _imgService;
        public ApplicationUserAPIController(IApplicationUserService userService, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, 
            IImageService imageService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userService = userService;
            _dbContext = dbContext;
            _imgService = imageService;
            _roleManager = roleManager;
        }

        // GET: api/ApplicationUserAPI
        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var user = await _userManager.GetUserAsync(User);
            var selectedRoleNames = await _userManager.GetRolesAsync(user);
            if (selectedRoleNames.FirstOrDefault() == "Admin")
                return DataSourceLoader.Load<ApplicationUser>(_userService.GetAllUsers().AsQueryable(), loadOptions);
            else if (selectedRoleNames.FirstOrDefault() == "Registration-Manager")
            {
                return DataSourceLoader.Load<ApplicationUser>(_userService.GetAllEntreprenuerAndOrganizationUsers().AsQueryable(), loadOptions);
            }
            else
                return null;
        }
        // DELETE: api/CallBacksAPI/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user.Photo != null)
            {
                _imgService.DeleteImage(user.Photo, "Users");
            }
            await _userManager.DeleteAsync(user);
        }

    }
}