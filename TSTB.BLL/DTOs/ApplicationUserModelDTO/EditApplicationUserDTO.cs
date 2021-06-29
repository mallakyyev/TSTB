using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ApplicationUserModelDTO
{
    public class EditApplicationUserDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан User Name")]
        public string UserName { get; set; }       

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string SecondName { get; set; }

        [Required]
        public DateTime? DateBirthday { get; set; }

        public int? OrganizationId { get; set; }

        public SelectList RolesList { get; set; }

        [Required]
        public string Role { get; set; }    

        public IFormFile Image { get; set; }
        public string Photo { get; set; }

    
        public DAL.Models.Enums.EntreprenuerType? EntreprenuerType { get; set; }

    }
}
