using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using AjaxDemo.LinqToSqlData;

namespace AjaxPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            //Thread.Sleep(2000);
            var db = new PersonRepository(Properties.Settings.Default.ConStr);
            return Json(db.GetPeople(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            var db = new PersonRepository(Properties.Settings.Default.ConStr);
            db.AddPerson(person);
            return Json(person);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            var db = new PersonRepository(Properties.Settings.Default.ConStr);
            db.Update(person);
            return Json(person);
        }

        [HttpPost]
        public void Delete(int id)
        {
            //PersonDb db = new PersonDb(Properties.Settings.Default.ConStr);
            //db.Delete(id);
        }
    }
}