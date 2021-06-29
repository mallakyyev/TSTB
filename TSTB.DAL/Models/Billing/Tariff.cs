using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.Billing
{
    public class Tariff
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public EntreprenuerType EntreprenuerType { get; set; }
        public double Amount { get; set; }
        public double EntryAmount { get; set; }
    }
}
