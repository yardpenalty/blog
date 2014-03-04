using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        //CONSTRUCTOR CHAINING EXAMPLE: this(new Contact...
        //
        //
        //public class ContactController : Controller
        //{
        //    private readonly IContactRepository iRepository;

        //    public ContactController()
        //        : this(new ContactManagerEntityRepository())
        //    { }

        //    public ContactController(IContactRepository repository)
        //    {
        //        iRepository = repository;
        //    }

        //    public ActionResult Index()
        //    {
        //        return View(iRepository.GetContacts());
        //    }
        //}
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Comment()
        {
            return PartialView();
        }

        public string TellMeDate()
        {
            return DateTime.Now.ToString();
        }

        public string ShowUsers()
        {
            string temp = Membership.GetNumberOfUsersOnline().ToString();
            string blank = "";
            if (String.Compare(temp, blank) == 0)
            {
                temp = "There was noone online!";

                return temp;
            }

            return temp;
        }


        public string ShowUsersOnline()
        {
            //string temp = Membership.GetNumberOfUsersOnline().ToString();
            string temp1 = "Supercalifragalistic";
            //if(String.Compare(temp, "") == 0)
            //{
            //    temp = "There was noone online!";

            //    return temp;
            //}
            //if(temp != null)
            //    temp = "The string was not null!";
            return temp1;
        }

    }
}
