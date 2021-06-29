using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MembershipRequestDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.MembershipRequest
{
    public class MembershipRequestService : IMembershipRequestService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IImageService _imageService;
        public MembershipRequestService(ApplicationDbContext dbContext, IImageService imageService)
        {
            _dbContext = dbContext;
            _imageService = imageService;
        }
        public async Task CreateMembershipRequestForEntreprenuer(CreateMembershipRequestForEntreprenuerDTO model)
        {
            TSTB.DAL.Models.MembershipRequest.MembershipRequest mm = new DAL.Models.MembershipRequest.MembershipRequest();
            mm.MembershipType = DAL.Models.Enums.MembershipType.Entreprenuer;
            mm.MembershipRequestStatus = DAL.Models.Enums.MembershipRequestStatus.UnderReqiew;
            mm.PhoneNumber = model.PhoneNumber;
            mm.Patent_Ustaw = await _imageService.UploadImage(model.Patent_Ustaw_FormFile, "MembershipRequests");
            mm.RegistrUdost_EGRPO = await _imageService.UploadImage(model.RegistrUdost_EGRPO_FormFile, "MembershipRequests");
            mm.Passport = await _imageService.UploadImage(model.Passport_FormFile, "MembershipRequests");
            mm.Declaration_Certificate = await _imageService.UploadImage(model.Declaration_Certificate_FormFile, "MembershipRequests");
            mm.EnqueryFrom = await _imageService.UploadImage(model.EnqueryFrom_FormFile, "MembershipRequests");
            mm.PrivateForm = await _imageService.UploadImage(model.PrivateForm_FormFile, "MembershipRequests");
            mm.SchoolCertificate = await _imageService.UploadImage(model.SchoolCertificate_FormFile, "MembershipRequests");
            await _dbContext.MembershipRequests.AddAsync(mm);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateMembershipRequestForLegalPerson(CreateMembrshipRequestForLegalPersonDTO model)
        {
            TSTB.DAL.Models.MembershipRequest.MembershipRequest mm = new DAL.Models.MembershipRequest.MembershipRequest();
            mm.MembershipType = DAL.Models.Enums.MembershipType.LegalPerson;
            mm.MembershipRequestStatus = DAL.Models.Enums.MembershipRequestStatus.UnderReqiew;
            mm.PhoneNumber = model.PhoneNumber;

            mm.Patent_Ustaw = await _imageService.UploadImage(model.Patent_Ustaw_FormFile, "MembershipRequests");
            mm.RegistrUdost_EGRPO = await _imageService.UploadImage(model.RegistrUdost_EGRPO_FormFile, "MembershipRequests");
            mm.Passport = await _imageService.UploadImage(model.Passport_FormFile, "MembershipRequests");
            mm.Declaration_Certificate = await _imageService.UploadImage(model.Declaration_Certificate_FormFile, "MembershipRequests");
            mm.EnqueryFrom = await _imageService.UploadImage(model.EnqueryFrom_FormFile, "MembershipRequests");
            mm.PrivateForm = await _imageService.UploadImage(model.PrivateForm_FormFile, "MembershipRequests");
            mm.SchoolCertificate = await _imageService.UploadImage(model.SchoolCertificate_FormFile, "MembershipRequests");
            mm.CommandOrder = await _imageService.UploadImage(model.CommandOrder_FormFile, "MembershipRequests");
            mm.IncomeReport = await _imageService.UploadImage(model.IncomeReport_FormFile, "MembershipRequests");
            await _dbContext.MembershipRequests.AddAsync(mm);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMembershipRequestById(int id)
        {
            TSTB.DAL.Models.MembershipRequest.MembershipRequest mm = await _dbContext.MembershipRequests.FindAsync(id);
               if(mm!= null)
                 {
                    if (!string.IsNullOrEmpty(mm.Patent_Ustaw))
                        _imageService.DeleteImage(mm.Patent_Ustaw, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.RegistrUdost_EGRPO))
                        _imageService.DeleteImage(mm.RegistrUdost_EGRPO, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.Passport))
                        _imageService.DeleteImage(mm.Passport, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.Declaration_Certificate))
                        _imageService.DeleteImage(mm.Declaration_Certificate, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.EnqueryFrom))
                        _imageService.DeleteImage(mm.EnqueryFrom, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.PrivateForm))
                        _imageService.DeleteImage(mm.PrivateForm, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.SchoolCertificate))
                        _imageService.DeleteImage(mm.SchoolCertificate, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.CommandOrder))
                        _imageService.DeleteImage(mm.CommandOrder, "MembershipRequests");
                    if (!string.IsNullOrEmpty(mm.IncomeReport))
                        _imageService.DeleteImage(mm.IncomeReport, "MembershipRequests");

                     _dbContext.MembershipRequests.Remove(mm);
                     await _dbContext.SaveChangesAsync();
                 }
        }

        public async Task EditMembershipRequestForEntreprenuer(EditMembershipRequestForEntreprenuerDTO model)
        {
            //Create model for update
            TSTB.DAL.Models.MembershipRequest.MembershipRequest mm = new DAL.Models.MembershipRequest.MembershipRequest();
            mm.Id = model.Id;
            mm.MembershipType = DAL.Models.Enums.MembershipType.Entreprenuer;
            mm.MembershipRequestStatus = model.MembershipRequestStatus;
            mm.PhoneNumber = model.PhoneNumber;
            // Keep picture names
            mm.Patent_Ustaw = model.Patent_Ustaw_Picture;
            mm.RegistrUdost_EGRPO = model.RegistrUdost_EGRPO_Picture;
            mm.Passport = model.Passport_Picture;
            mm.Declaration_Certificate = model.Declaration_Certificate_Picture;
            mm.EnqueryFrom = model.EnqueryFrom_Picture;
            mm.PrivateForm = model.PrivateForm_Picture;
            mm.SchoolCertificate = model.SchoolCertificate_Picture;

            //Upload image if IFormFile not empty
            if (model.Patent_Ustaw_FormFile != null)
            {
                _imageService.DeleteImage(mm.Patent_Ustaw, "MembershipRequests");
                mm.Patent_Ustaw = await _imageService.UploadImage(model.Patent_Ustaw_FormFile, "MembershipRequests");
            }

            if (model.RegistrUdost_EGRPO_FormFile != null)
            {
                _imageService.DeleteImage(mm.RegistrUdost_EGRPO, "MembershipRequests");
                mm.RegistrUdost_EGRPO = await _imageService.UploadImage(model.RegistrUdost_EGRPO_FormFile, "MembershipRequests");
            }

            if (model.Passport_FormFile != null)
            {
                _imageService.DeleteImage(mm.Passport, "MembershipRequests");
                mm.Passport = await _imageService.UploadImage(model.Passport_FormFile, "MembershipRequests");
            }

            if (model.Declaration_Certificate_FormFile != null)
            {
                _imageService.DeleteImage(mm.Declaration_Certificate, "MembershipRequests");
                mm.Declaration_Certificate = await _imageService.UploadImage(model.Declaration_Certificate_FormFile, "MembershipRequests");
            }

            if (model.EnqueryFrom_FormFile != null)
            {
                _imageService.DeleteImage(mm.EnqueryFrom, "MembershipRequests");
                mm.EnqueryFrom = await _imageService.UploadImage(model.EnqueryFrom_FormFile, "MembershipRequests");
            }

            if (model.PrivateForm_FormFile != null)
            {
                _imageService.DeleteImage(mm.PrivateForm, "MembershipRequests");
                mm.PrivateForm = await _imageService.UploadImage(model.PrivateForm_FormFile, "MembershipRequests");
            }

            if (model.SchoolCertificate_FormFile != null)
            {
                _imageService.DeleteImage(mm.SchoolCertificate, "MembershipRequests");
                mm.SchoolCertificate = await _imageService.UploadImage(model.SchoolCertificate_FormFile, "MembershipRequests");
            }

            // Update Database
             _dbContext.MembershipRequests.Update(mm);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditMembershipRequestForLegalPerson(EditMembershipRequestForLegalPersonDTO model)
        {
            //Create model for update
            TSTB.DAL.Models.MembershipRequest.MembershipRequest mm = new DAL.Models.MembershipRequest.MembershipRequest();
            mm.Id = model.Id;
            mm.MembershipType = DAL.Models.Enums.MembershipType.LegalPerson;
            mm.MembershipRequestStatus = model.MembershipRequestStatus;
            mm.PhoneNumber = model.PhoneNumber;

            // Keep picture names
            mm.Patent_Ustaw = model.Patent_Ustaw_Picture;
            mm.RegistrUdost_EGRPO = model.RegistrUdost_EGRPO_Picture;
            mm.Passport = model.Passport_Picture;
            mm.Declaration_Certificate = model.Declaration_Certificate_Picture;
            mm.EnqueryFrom = model.EnqueryFrom_Picture;
            mm.PrivateForm = model.PrivateForm_Picture;
            mm.SchoolCertificate = model.SchoolCertificate_Picture;
            mm.CommandOrder = model.CommandOrder_Picture;
            mm.IncomeReport = model.IncomeReport_Picture;

            //Upload image if IFormFile not empty
            if (model.Patent_Ustaw_FormFile != null)
            {
                _imageService.DeleteImage(mm.Patent_Ustaw, "MembershipRequests");
                mm.Patent_Ustaw = await _imageService.UploadImage(model.Patent_Ustaw_FormFile, "MembershipRequests");
            }

            if (model.RegistrUdost_EGRPO_FormFile != null)
            {
                _imageService.DeleteImage(mm.RegistrUdost_EGRPO, "MembershipRequests");
                mm.RegistrUdost_EGRPO = await _imageService.UploadImage(model.RegistrUdost_EGRPO_FormFile, "MembershipRequests");
            }

            if (model.Passport_FormFile != null)
            {
                _imageService.DeleteImage(mm.Passport, "MembershipRequests");
                mm.Passport = await _imageService.UploadImage(model.Passport_FormFile, "MembershipRequests");
            }

            if (model.Declaration_Certificate_FormFile != null)
            {
                _imageService.DeleteImage(mm.Declaration_Certificate, "MembershipRequests");
                mm.Declaration_Certificate = await _imageService.UploadImage(model.Declaration_Certificate_FormFile, "MembershipRequests");
            }

            if (model.EnqueryFrom_FormFile != null)
            {
                _imageService.DeleteImage(mm.EnqueryFrom, "MembershipRequests");
                mm.EnqueryFrom = await _imageService.UploadImage(model.EnqueryFrom_FormFile, "MembershipRequests");
            }

            if (model.PrivateForm_FormFile != null)
            {
                _imageService.DeleteImage(mm.PrivateForm, "MembershipRequests");
                mm.PrivateForm = await _imageService.UploadImage(model.PrivateForm_FormFile, "MembershipRequests");
            }

            if (model.SchoolCertificate_FormFile != null)
            {
                _imageService.DeleteImage(mm.SchoolCertificate, "MembershipRequests");
                mm.SchoolCertificate = await _imageService.UploadImage(model.SchoolCertificate_FormFile, "MembershipRequests");
            }

            if (model.CommandOrder_FormFile != null)
            {
                _imageService.DeleteImage(mm.CommandOrder, "MembershipRequests");
                mm.SchoolCertificate = await _imageService.UploadImage(model.CommandOrder_FormFile, "MembershipRequests");
            }

            if (model.IncomeReport_FormFile != null)
            {
                _imageService.DeleteImage(mm.IncomeReport, "MembershipRequests");
                mm.SchoolCertificate = await _imageService.UploadImage(model.IncomeReport_FormFile, "MembershipRequests");
            }

            // Update Database
            _dbContext.MembershipRequests.Update(mm);
            await _dbContext.SaveChangesAsync();
        }

        public ICollection<DAL.Models.MembershipRequest.MembershipRequest> GetAllMembershipRequests()
        {
            List<DAL.Models.MembershipRequest.MembershipRequest> res = new List<DAL.Models.MembershipRequest.MembershipRequest>(
                _dbContext.MembershipRequests);
            return res;
        }

        public async Task<DAL.Models.MembershipRequest.MembershipRequest> GetMembershipRequestById(int id)
        {
            DAL.Models.MembershipRequest.MembershipRequest res = await _dbContext.MembershipRequests.FindAsync(id);
            return res;
        }

        public async Task<EditMembershipRequestForEntreprenuerDTO> GetMembershipRequestForEditEntreprenuerById(int id)
        {
            DAL.Models.MembershipRequest.MembershipRequest mm = await _dbContext.MembershipRequests.FindAsync(id);
            EditMembershipRequestForEntreprenuerDTO res = new EditMembershipRequestForEntreprenuerDTO();

            res.Patent_Ustaw_Picture = mm.Patent_Ustaw;
            res.RegistrUdost_EGRPO_Picture = mm.RegistrUdost_EGRPO;
            res.Passport_Picture = mm.Passport;
            res.Declaration_Certificate_Picture = mm.Declaration_Certificate;
            res.EnqueryFrom_Picture = mm.EnqueryFrom;
            res.PrivateForm_Picture = mm.PrivateForm;
            res.SchoolCertificate_Picture = mm.SchoolCertificate;
            res.MembershipRequestStatus = mm.MembershipRequestStatus;
            res.Id = mm.Id;

            return res;
        }

        public async Task<EditMembershipRequestForLegalPersonDTO> GetMembershipRequestForEditLegalPersonById(int id)
        {
            DAL.Models.MembershipRequest.MembershipRequest mm = await _dbContext.MembershipRequests.FindAsync(id);
            EditMembershipRequestForLegalPersonDTO res = new EditMembershipRequestForLegalPersonDTO();

            res.Patent_Ustaw_Picture = mm.Patent_Ustaw;
            res.RegistrUdost_EGRPO_Picture = mm.RegistrUdost_EGRPO;
            res.Passport_Picture = mm.Passport;
            res.Declaration_Certificate_Picture = mm.Declaration_Certificate;
            res.EnqueryFrom_Picture = mm.EnqueryFrom;
            res.PrivateForm_Picture = mm.PrivateForm;
            res.SchoolCertificate_Picture = mm.SchoolCertificate;
            res.MembershipRequestStatus = mm.MembershipRequestStatus;
            res.CommandOrder_Picture = mm.CommandOrder;
            res.IncomeReport_Picture = mm.IncomeReport;
            res.Id = mm.Id;

            return res;
        }
    }
}
