using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class SubscriberDbContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}