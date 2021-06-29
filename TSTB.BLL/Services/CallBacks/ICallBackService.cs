using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CallBackModelDTO;

namespace TSTB.BLL.Services.CallBacks
{
    public interface  ICallBackService
    {
        IEnumerable<CallBackDTO> GetAllCallBacks();
        IEnumerable<CallBackDTO> GetAllCashCallBacks();
        IEnumerable<CallBackDTO> GetAllPublishcallBacks();

        Task CreateCallBack(CreateCallBackDTO modelDTO);

        Task EditCallBack(EditCallBackDTO modelDTO);
        Task<CallBackDTO> getCallBackById(int callBackId);
        Task RemoveCallBack(int id);
        Task RemoveAllCallBacks();
        Task<EditCallBackDTO> GetCallBackForEditById(int id);
    }
}
