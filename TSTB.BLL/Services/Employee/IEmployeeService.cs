using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Billing;

namespace TSTB.BLL.Services.Employee
{
    public interface IEmployeeService
    {
        ICollection<PaymentDTO> getAllPaymentByUserId(string id);
        ICollection<DeclarationDTO> getAllDeclarationByUserId(string id);
        ICollection<DeclarationAccount> getAllDeclarationByStatus();

        IEnumerable<DeclarationImage> GetAllDeclarationImageByDecId(int id);
        Task CreateDeclaration(CreateDeclarationDTO modelDTO, string id);
        Task DeleteDeclartionFiles(int id);
        Task EditDeclaration(EditDeclarationDTO modelDTO);
        Task<bool> EditDeclarationAcc(EditDeclatarionAccountant modelDTO); 
        Task CreatePayment(CreatePaymentDTO modelDTO);

        Task EditPayment(EditPaymentDTO modelDTO);
        Task DeleteDeclarationById(int id);
        Task DeleteDeclartionFilesById(int id);
        Task DeletePaymentById(int id);
        Task<EditDeclarationDTO> GetDeclarationForEditById(int id);
        Task<EditPaymentDTO> GetPaymentForEditById(int id);
        Task<ICollection<TransactionViewModel>> getAllTransactions();
        Task<Payment> GetPaymentById(int id);
        Task<Payment> EditPayment(Payment modelDTO);
        Task<Payment> GetPaymentByOrderNumber(string orderNumber);
    }
}
