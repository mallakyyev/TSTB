using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.MembershipRequestDTO
{
    public class EditMembershipRequestForEntreprenuerDTO
    {
        public int Id { get; set; }

        
        public string Patent_Ustaw_Picture { get; set; }

        
        public string RegistrUdost_EGRPO_Picture { get; set; }

        
        public string Passport_Picture { get; set; }

        
        public string Declaration_Certificate_Picture { get; set; }

        
        public string EnqueryFrom_Picture { get; set; }

        
        public string PrivateForm_Picture { get; set; }

        
        public string SchoolCertificate_Picture { get; set; }

        [Required]
        public MembershipRequestStatus MembershipRequestStatus { get; set; }

        public IFormFile Patent_Ustaw_FormFile { get; set; }

        
        public IFormFile RegistrUdost_EGRPO_FormFile { get; set; }

        
        public IFormFile Passport_FormFile { get; set; }

        
        public IFormFile Declaration_Certificate_FormFile { get; set; }

        
        public IFormFile EnqueryFrom_FormFile { get; set; }

        
        public IFormFile PrivateForm_FormFile { get; set; }

        
        public IFormFile SchoolCertificate_FormFile { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
