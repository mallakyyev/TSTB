using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.BLL.DTOs.OrganizationModelDTO;
using TSTB.BLL.Services.ApplicationUser;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.Services.Language;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Admin.Models;
using TSTB.Web.Data;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Registration-Manager")]
    public class ApplicationUserController : Controller
    {
        
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContex;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IApplicationUserService _applicationUserService;
        private readonly IImageService _imageService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ApplicationUserController(ILanguageService langService, IMapper mapper, RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager, IImageService imageService, ApplicationDbContext dbContext, 
            IStringLocalizer<SharedResource> localizer)
        {
            _mapper = mapper;
            _imageService = imageService;
            _languageService = langService;
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContex = dbContext;
            _localizer = localizer;

        }
        // GET: Admin/ApplicationUser
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/ApplicationUser/Create
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var selectedRoleNames = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = selectedRoleNames.FirstOrDefault();
            ViewBag.ErrorList = null;
            var roles = await _roleManager.Roles.Where(p => p.Name != "Entrepreneur").ToListAsync();
            ViewBag.RolesList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(roles.OrderBy(o => o.Name), "Name", "Name");
            CreateUserAndOrganizationModel model = new CreateUserAndOrganizationModel();
            model.CraeteApplicationUserDTO = new CreateApplicationUserDTO();
            model.CraeteApplicationUserDTO.EntreprenuerType = DAL.Models.Enums.EntreprenuerType.Employee;            
            model.CreateOrganizationDTO = new CreateOrganizationDTO();
            model.CreateOrganizationDTO.MembershipDate = DateTime.Today;
            model.CreateOrganizationDTO.IssuedDate = DateTime.Today;
            return View(model);
        }

        // Post: Admin/ApplicationUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserAndOrganizationModel model)
        {
            var roles = await _roleManager.Roles.Where(p => p.Name != "Entrepreneur").ToListAsync();
            ViewBag.RolesList = new SelectList(roles.OrderBy(o => o.Name), "Name", "Name", model.CraeteApplicationUserDTO.Role);

            //////////////////// Check for Registration-Manager Role to not create Admin Role User ////////////////
            var user1 = await _userManager.GetUserAsync(User);
            var selectedRoleNames = await _userManager.GetRolesAsync(user1);
            if(selectedRoleNames.FirstOrDefault() != "Admin" && model.CraeteApplicationUserDTO.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Employee)
            {
                List<string> ErrorList = new List<string>();
                ErrorList.Add(_localizer["Not enought priviliges to create this account !!"]);
                ViewBag.ErrorList1 = ErrorList;
                return View(model);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if (model.CraeteApplicationUserDTO.EntreprenuerType != DAL.Models.Enums.EntreprenuerType.Employee)
            {
                if (ModelState.IsValid)
                {
                    
                    ApplicationUser user = _mapper.Map<ApplicationUser>(model.CraeteApplicationUserDTO);
                    user.EmailConfirmed = true;
                    var result = await _userManager.CreateAsync(user, model.CraeteApplicationUserDTO.Password);

                    if (result.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(user, "Entrepreneur");
                       
                        if (model.CraeteApplicationUserDTO.Image != null)
                        {
                            user.Photo = await _imageService.UploadImage(model.CraeteApplicationUserDTO.Image, "Users");
                            await _userManager.UpdateAsync(user);
                        }
                        model.CreateOrganizationDTO.ApplicationUserId = user.Id;
                        var org = _mapper.Map<Organization>(model.CreateOrganizationDTO);
                        await _dbContex.Organizations.AddAsync(org);
                        await _dbContex.SaveChangesAsync();
                        user.OrganizationId = org.Id;
                        await _userManager.UpdateAsync(user);        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorList = result.Errors.ToList();
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }else
            {
                if(model.CraeteApplicationUserDTO.Password != model.CraeteApplicationUserDTO.ConfirmPassword)
                {
                    List<string> ErrorList = new List<string>();
                    ErrorList.Add(_localizer["Password and confirm password does not match"]);
                    ViewBag.ErrorList = ErrorList;
                    return View(model);
                }
                ApplicationUser user = _mapper.Map<ApplicationUser>(model.CraeteApplicationUserDTO);
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, model.CraeteApplicationUserDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.CraeteApplicationUserDTO.Role);                  
                    if (model.CraeteApplicationUserDTO.Image != null)
                    {
                        user.Photo = await _imageService.UploadImage(model.CraeteApplicationUserDTO.Image, "Users");
                        await _userManager.UpdateAsync(user);
                    }                  
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorList = result.Errors.ToList();
                    return View(model);
                }
            }  
        }

        [HttpGet]
        // GET: Admin/ApplicationUser/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            //Get application user for edit by Id
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            EditApplicationUserDTO editUser = _mapper.Map<EditApplicationUserDTO>(user);
            EditUserAndOrganizationModel userANDorg = new EditUserAndOrganizationModel();
            userANDorg.EditApplicationUserDTO = editUser;

            var roles = await _roleManager.Roles.Where(p => p.Name != "Entrepreneur").ToListAsync();
            var selectedRoleNames = await _userManager.GetRolesAsync(user);
            ViewBag.RolesList = new SelectList(roles.OrderBy(o => o.Name), "Name", "Name", selectedRoleNames.FirstOrDefault());
            editUser.Role = selectedRoleNames.FirstOrDefault();
            //Get Orginazation user for edit by Id
            var org = await _dbContex.Organizations.SingleOrDefaultAsync(p => p.ApplicationUserId == id);
            if (org != null)
            {
                EditOrganizationDTO editOrg = _mapper.Map<EditOrganizationDTO>(org);  
                userANDorg.EditOrganizationDTO = editOrg;
            }
            
            return View(userANDorg);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserAndOrganizationModel model)
        {
            //////////////////// Check for Registration-Manager Role to not create Admin Role User ////////////////
            var user1 = await _userManager.GetUserAsync(User);
            var selectedRoleNames1 = await _userManager.GetRolesAsync(user1);
            if (selectedRoleNames1.FirstOrDefault() != "Admin" && model.EditApplicationUserDTO.EntreprenuerType == DAL.Models.Enums.EntreprenuerType.Employee)
            {               
                return View(model);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //var user = _mapper.Map<ApplicationUser>(model.EditApplicationUserDTO);
            var user = await _userManager.Users.SingleOrDefaultAsync(p => p.Id == model.EditApplicationUserDTO.Id);
            user.FirstName = model.EditApplicationUserDTO.FirstName;
            user.UserName = model.EditApplicationUserDTO.UserName;
            user.PhoneNumber = model.EditApplicationUserDTO.PhoneNumber;
            user.LastName = model.EditApplicationUserDTO.LastName;
            user.SecondName = model.EditApplicationUserDTO.SecondName;
            user.DateBirthday = model.EditApplicationUserDTO.DateBirthday;
            user.Email = model.EditApplicationUserDTO.Email;                  

       // public IFormFile Image { get; set; }
      //  public string Photo { get; set; }

        var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded){
                var selectedRoleNames = await _userManager.GetRolesAsync(user);
                if (model.EditApplicationUserDTO.Role != selectedRoleNames.FirstOrDefault())
                {
                        await _userManager.RemoveFromRolesAsync(user, selectedRoleNames);
                        await _userManager.AddToRoleAsync(user, model.EditApplicationUserDTO.Role);
                }            
                if (model.EditApplicationUserDTO.Image != null)
                {
                    _imageService.DeleteImage(user.Photo, "Users");
                    user.Photo = await _imageService.UploadImage(model.EditApplicationUserDTO.Image, "Users");
                    await _userManager.UpdateAsync(user);
                }
                            
                if (model.EditApplicationUserDTO.EntreprenuerType != DAL.Models.Enums.EntreprenuerType.Employee && model.EditOrganizationDTO.NameOrganization != null)
                {
                    if (ModelState.IsValid)
                    {
                        var org = _mapper.Map<Organization>(model.EditOrganizationDTO);
                        org.ApplicationUserId = user.Id;
                        _dbContex.Organizations.Update(org);
                        await _dbContex.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var roles = await _roleManager.Roles.Where(p => p.Name != "Entrepreneur").ToListAsync();
                ViewBag.RolesList = new SelectList(roles.OrderBy(o => o.Name), "Name", "Name", model.EditApplicationUserDTO.Role);
                ViewBag.ErrorList = result.Errors.ToList();
                return View(model);
            }
        }

        [HttpGet]
        // GET: Admin/ApplicationUser/ChangePassword/{id}
        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
            {
                return NotFound();
            }else
            {
                var c = await _userManager.GeneratePasswordResetTokenAsync(user);
                var c1= WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(c));
                
                ChangePasswordModel userForChangePass = new ChangePasswordModel
                {
                    Email = await _userManager.GetEmailAsync(user),
                    UserName = user.UserName,
                    Id = id
                };
                return View(userForChangePass);
            }
            
        }

        [HttpPost]
        // GET: Admin/ApplicationUser/Edit/5
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                ViewBag.ErrorList = "User does not exists";
                return View();
            }
            var Code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
           else
            {
                ViewBag.ErrorList = result.Errors.ToList();
                return View(model);
            }
           
        }

        // GET: Admin/ApplicationUser/Delete/5
        public IActionResult Delete(string id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}