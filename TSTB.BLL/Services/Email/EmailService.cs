using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.Services.ApplicationUser;
using System.Linq;
using MailKit.Security;
using TSTB.Web.Data;
using TSTB.BLL.DTOs.EmailsModelDTO;

namespace TSTB.BLL.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IApplicationUserService _userService;
        private readonly ApplicationDbContext _dbContext;
        
        public EmailService(IApplicationUserService userService,ApplicationDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }
        public async Task<bool> SendEmail(EmailsDTO emails)
        {
            List<string> entrEmail = new List<string>();
            if (emails.SendedToEntrepreneur)
                entrEmail.AddRange(_userService.GetAllEntreprenuerEmails());
            if (emails.SendedToOrganization)
                entrEmail.AddRange(_userService.GetAllorganizationEmails());
            if (emails.SendedToSubscribers)
                entrEmail.AddRange(_dbContext.Subscribers.Select(p => p.Email));

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(emails.Header, emails.AdminEmail));
                emailMessage.To.AddRange(entrEmail.Select(p=> new MailboxAddress("",p)) );
                emailMessage.Subject = emails.Subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = emails.Message
                };

            try
            {
                string smtp = "smtp." + emails.AdminEmail.Substring(emails.AdminEmail.IndexOf("@")+1);
                using var client = new SmtpClient();
                await client.ConnectAsync(smtp, 587, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(emails.AdminEmail, emails.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }catch(Exception e)
            {

                return false;
            }
            return true;
            
        }

        public async Task<bool> SendSingleEmail(SingleEmailDTO emails)
        {
  
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", emails.AdminEmail));
            emailMessage.To.Add(new MailboxAddress("",emails.EmailTo));
            emailMessage.Subject = emails.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emails.Message
            };

            try
            {
                string smtp = "smtp." + emails.AdminEmail.Substring(emails.AdminEmail.IndexOf("@") + 1);
                using var client = new SmtpClient();
                await client.ConnectAsync(smtp, 587, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(emails.AdminEmail, emails.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
