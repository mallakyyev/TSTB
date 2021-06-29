using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.CallBacks;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecondName { get; set; }

        public DateTime? DateBirthday { get; set; }

        /// <summary>
        /// Наименование файла
        /// </summary>
        public string Photo { get; set; }

        public int? OrganizationId { get; set; }
        public EntreprenuerType? EntreprenuerType { get; set; }
        public Organization Organization { get; set; }
        public ICollection<PaymentCharity> PaymentCharity { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Declaration> Declaration { get; set; }
    }
}
