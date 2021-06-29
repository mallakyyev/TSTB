using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.OrganizationModelDTO
{
    public class OrganizationDTO
    {
        public int Id { get; set; }

        [Required]
        public string TaxCode { get; set; }

        [Required]
        public string NameOrganization { get; set; }

        [Required]

        public string Activity { get; set; }

        [Required]
        public string AddressOrganization { get; set; }

        [Required]
        public string PhoneOrganization { get; set; }
        [Required]

        public DateTime MembershipDate { get; set; }
        
        [Required]
        public Sex Sex { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        [Required]
        public string PassportSN { get; set; }

        [Required]
        public string IssuedBy { get; set; }
        
        [Required]
        public DateTime IssuedDate { get; set; }

        [Required]
        public string PlaceRegistration { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

    }
}
