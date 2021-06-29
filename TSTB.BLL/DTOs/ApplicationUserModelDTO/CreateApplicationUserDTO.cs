using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.ApplicationUserModelDTO
{
    public class CreateApplicationUserDTO
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Не указан User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string SecondName { get; set; }

        public DateTime? DateBirthday { get; set; }

        public int? OrganizationId { get; set; }

        public SelectList RolesList { get; set; }

        public string Role { get; set; }

        public IFormFile Image { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public EntreprenuerType? EntreprenuerType { get; set; }

    }
}
