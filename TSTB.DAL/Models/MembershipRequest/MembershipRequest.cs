using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.MembershipRequest
{
    public class MembershipRequest
    {
        public int Id { get; set; }
        public string Patent_Ustaw { get; set; }
        public string RegistrUdost_EGRPO { get; set; }
        public string Passport { get; set; }
        public string CommandOrder { get; set; }
        public string IncomeReport { get; set; }
        public string Declaration_Certificate { get; set; }
        public string EnqueryFrom { get; set; }
        public string PrivateForm { get; set; }
        public string SchoolCertificate { get; set; }
        public MembershipType MembershipType { get; set; }
        public string PhoneNumber { get; set; }
        public MembershipRequestStatus MembershipRequestStatus { get; set; }
    }

}
