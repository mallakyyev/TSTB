using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MembershipRequestDTO;

namespace TSTB.BLL.Services.MembershipRequest
{
    public interface IMembershipRequestService
    {
        public Task CreateMembershipRequestForEntreprenuer(CreateMembershipRequestForEntreprenuerDTO model);
        public Task EditMembershipRequestForEntreprenuer(EditMembershipRequestForEntreprenuerDTO model);
        public Task CreateMembershipRequestForLegalPerson(CreateMembrshipRequestForLegalPersonDTO model);
        public Task EditMembershipRequestForLegalPerson(EditMembershipRequestForLegalPersonDTO model);
        public Task DeleteMembershipRequestById(int id);
        public ICollection<TSTB.DAL.Models.MembershipRequest.MembershipRequest> GetAllMembershipRequests();
        public Task<TSTB.DAL.Models.MembershipRequest.MembershipRequest> GetMembershipRequestById(int id);
        public Task<EditMembershipRequestForEntreprenuerDTO> GetMembershipRequestForEditEntreprenuerById(int id);
        public Task<EditMembershipRequestForLegalPersonDTO> GetMembershipRequestForEditLegalPersonById(int id);

    }
}
