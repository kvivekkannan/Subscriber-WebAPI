using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SubscriberRepository subRep = new SubscriberRepository();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";
            return View();
        }
        public ActionResult Subscribers()
        {
            ViewBag.Title = "Home - Subscribers";
            
            return View();
        }

        public JsonResult GetSubscribersJson()
        {
            var subs = GetSubscriberData();
            return Json(subs, JsonRequestBehavior.AllowGet);
        }

        [Route("EditSubscriber")]
        [HttpGet]
        public ActionResult EditSubscriber(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Edit details";
                return View(id);
            }
            else
                return View();
        }
        
        public ActionResult DeleteSubscriber(int? id)
        {
            if (id != null)
            {                
                return View(id);
            }
            else
                return View();
        }
        private IEnumerable<Subscriber> GetSubscriberData()
        {
            var SubscriberList = new List<Subscriber>();
            SubscriberList = (List<Subscriber>)subRep.GetSubscribers();
            return SubscriberList;

        }
    }
}
