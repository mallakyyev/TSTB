using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;


namespace TSTB.BLL.Services.ApplicationUser
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDTO> GetUserProfile(string userId);
        IEnumerable<TSTB.DAL.Models.User.ApplicationUser> GetAllUsers();
        IEnumerable<TSTB.DAL.Models.User.ApplicationUser> GetAllEntreprenuerAndOrganizationUsers();
        IEnumerable<string> GetAllEntreprenuerEmails();
        IEnumerable<string> GetAllorganizationEmails();
        //IEnumerable<TSTB.DAL.Models.User.ApplicationUser> GetAllInterpreneurAndOrg();
        Task DeleteUser(string id);
    }
}
