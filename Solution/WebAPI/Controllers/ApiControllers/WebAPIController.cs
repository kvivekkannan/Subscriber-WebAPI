using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.UnitOfWorks;

namespace WebAPI.Controllers.ApiControllers
{
    [RoutePrefix("api/WebAPI")]
    public class WebAPIController : ApiController
    {
        SubscriberUnitOfWork uowSub = new SubscriberUnitOfWork(new SubscriberDbContext());

        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate(Subscriber subscriber)
        {
            var auth = uowSub.subscriberRepo.AuthenticateSubscriberOnLogin(subscriber);
            if (auth != null)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Registration")]
        public IHttpActionResult Registration(Subscriber subscriber)
        {
            uowSub.subscriberRepo.AddSubscriberDetails(subscriber);
            uowSub.SaveUoW();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetResult()
        {
            return Ok(uowSub.subscriberRepo.GetSubscribers());
        }

        [HttpPost]
        [Route("UpdateSubscriberDetails")]
        public IHttpActionResult UpdateSubscriberDetails(Subscriber subscriber)
        {
            var id = subscriber.SubscriberID;
            if (subscriber != null)
            {
                uowSub.subscriberRepo.EditSubscriberDetails(id, subscriber);
                uowSub.SaveUoW();
                return Ok();
            }                
            else
                return BadRequest();
        }


        [HttpPost]
        public IHttpActionResult DeleteSubscriber(int id)
        {
            uowSub.subscriberRepo.DeleteSubscriberDetailsById(id);
            uowSub.SaveUoW();
            return Ok();
        }
    }
}
