using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.EmailsModelDTO
{
    public class EmailsDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool SendedToEntrepreneur { get; set; }
        public bool SendedToOrganization { get; set; }
        public bool SendedToSubscribers { get; set; }
        public string Header { get; set; }
        public string AdminEmail { get; set; }
        public string Password { get; set; }
    }
}
