using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.EmailsModelDTO;


namespace TSTB.BLL.Services.Email
{
    public interface IEmailService
    {
         Task<bool> SendEmail(EmailsDTO emails);
        Task<bool> SendSingleEmail(SingleEmailDTO email);
        
    }

}
