using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;
using TSTB.DAL.Models.User;
namespace TSTB.DAL.Models.Billing
{
    public class Declaration
    {
        public int Id{ get; set; }
        public DateTime DateCreateDeclaration{ get; set; }
        public StatusDeclaration StatusDeclaration { get; set; }
        public string Description{ get; set; }
        public int YearDeclaration { get; set; }
        public string ApplicationUserId{ get; set; }
        public int? PaymentId{ get; set; }
        public Payment Payment{ get; set; }
        public IEnumerable<DeclarationImage> DeclarationImages{ get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
