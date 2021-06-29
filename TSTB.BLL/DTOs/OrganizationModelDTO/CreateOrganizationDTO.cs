using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.OrganizationModelDTO
{
    public class CreateOrganizationDTO
    {

        [Required]
        public string NameOrganization { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 11, ErrorMessage = "Tax Code number should have minimum 11 digits")]
        [Range(0, Int64.MaxValue, ErrorMessage = "Tax Code number should not contain characters")]
        public string TaxCode { get; set; }

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


        public string ApplicationUserId { get; set; }
    }
}
