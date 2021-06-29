using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Billing
{
    public class DeclarationImage
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int DeclarationId { get; set; }
        public Declaration Declaration{ get; set; }
    }
}
