using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.Enums;
using TSTB.DAL.Models.User;

namespace TSTB.BLL.ViewModel
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public StatusPayment? StatusPayment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOrganization { get; set; }
        public string TaxCode { get; set; }
        public int Year { get; set; }
    }
}
