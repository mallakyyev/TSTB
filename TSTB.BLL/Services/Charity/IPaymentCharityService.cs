using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.Services.Charity
{
    public interface IPaymentCharityService
    {
        Task<int> CreatePaymentCharity(CreatePaymentCharityDTO model);
        Task EditCharityService(EditPaymentCharityDTO model);
        ICollection<EditPaymentCharityDTO> GetAllPaymentCharity();
        Task<EditPaymentCharityDTO> GetCharityById(int id);
        Task RemovePaymentCharity(int id);
        Task GetPaymentByPaymentNumberforEdit(string id,string bid, StatusPayment st);
        Task DeleteByPaymentNumber(string id);
        IEnumerable<PaymentCharity> GetCharityDerails(int charId, string userId);
        IEnumerable<PaymentCharity> GetAllCharityByUser( string userId);
    }
}
