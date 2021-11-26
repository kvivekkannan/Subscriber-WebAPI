using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ISubscriberRepository
    {
        void AddSubscriberDetails(Subscriber subscriber);
        void DeleteSubscriberDetailsById(int id);
        Subscriber EditSubscriberDetails(int id, Subscriber subscriber);
        Subscriber GetSubscriberDetailById(int id);
        IEnumerable<Subscriber> GetSubscribers();
        Subscriber AuthenticateSubscriberOnLogin(Subscriber subscriber);
    }
}