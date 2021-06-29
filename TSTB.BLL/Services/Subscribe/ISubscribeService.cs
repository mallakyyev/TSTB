using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.DAL.Models.Email;

namespace TSTB.BLL.Services.Subscribe
{
    public interface ISubscribeService
    {
         Task<bool> AddSubscriber(Subscribers subscriber);
        Task DeleteSubscriber(string  id);
        IEnumerable<Subscribers> GetAllSubscribers();
        string GetEmail(string email);
    }
}
