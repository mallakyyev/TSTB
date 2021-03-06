using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.MembershipRequestDTO
{
    public class CreateMembershipRequestForEntreprenuerDTO
    {       
        [Required]
        public IFormFile Patent_Ustaw_FormFile { get; set; }

        [Required]
        public IFormFile RegistrUdost_EGRPO_FormFile { get; set; }

        [Required]
        public IFormFile Passport_FormFile { get; set; }

        [Required]
        public IFormFile Declaration_Certificate_FormFile { get; set; }

        [Required]
        public IFormFile EnqueryFrom_FormFile { get; set; }

        [Required]
        public IFormFile PrivateForm_FormFile { get; set; }

        [Required]
        public IFormFile SchoolCertificate_FormFile { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }


    }
}
