using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private SubscriberDbContext subsDb = new SubscriberDbContext();

        public SubscriberRepository()
        {
        }

        public SubscriberRepository(SubscriberDbContext subsDb)
        {
            this.subsDb = subsDb;
        }

        public IEnumerable<Subscriber> GetSubscribers()
        {
            return subsDb.Subscribers.ToList();
        }
        public void AddSubscriberDetails(Subscriber subscriber)
        {
            subsDb.Subscribers.Add(subscriber);
        }
        public Subscriber GetSubscriberDetailById(int id)
        {
            return subsDb.Subscribers.Find(id);
        }
        public Subscriber EditSubscriberDetails(int id, Subscriber subscriber)
        {
            var existingSubscriber = GetSubscriberDetailById(id);
            if (existingSubscriber != null)
            {
                existingSubscriber.SubscriberName = subscriber.SubscriberName;
                existingSubscriber.SubscriberEmail = subscriber.SubscriberEmail;
                existingSubscriber.SubscriberAge = subscriber.SubscriberAge;
                existingSubscriber.SubscriberUsername = subscriber.SubscriberUsername;
                existingSubscriber.SubscriberPassword = subscriber.SubscriberPassword;
            }
            return existingSubscriber;
        }
        public void DeleteSubscriberDetailsById(int id)
        {
            subsDb.Subscribers.Remove(GetSubscriberDetailById(id));
        }
        public Subscriber AuthenticateSubscriberOnLogin(Subscriber subscriber)
        {
            return subsDb.Subscribers.FirstOrDefault(u => u.SubscriberUsername == subscriber.SubscriberUsername && u.SubscriberPassword == subscriber.SubscriberPassword);
        }
    }
}