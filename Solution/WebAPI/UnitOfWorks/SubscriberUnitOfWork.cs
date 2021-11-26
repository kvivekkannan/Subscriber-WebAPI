using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Context;
using WebAPI.Repositories;

namespace WebAPI.UnitOfWorks
{
    public class SubscriberUnitOfWork : ISubscriberUnitOfWork
    {
        private readonly SubscriberDbContext subsDb;

        public SubscriberUnitOfWork()
        {
            subsDb = new SubscriberDbContext();
        }

        public SubscriberUnitOfWork(SubscriberDbContext subsDb)
        {
            this.subsDb = subsDb;
        }

        private ISubscriberRepository _subRepo;

        public ISubscriberRepository subscriberRepo
        {
            get
            {
                if (this._subRepo == null)
                {
                    this._subRepo = new SubscriberRepository(subsDb);
                }
                return this._subRepo;
            }
        }

        public int SaveUoW()
        {
            return subsDb.SaveChanges();
        }
    }
}