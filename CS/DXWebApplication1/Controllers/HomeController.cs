using System;
using System.Linq;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult GridViewPartial() {
            return PartialView(GetModel());
        }
        private object GetModel() {
            return Enumerable.Range(1, 100).Select(i => new MyModel { ID = i, Text = "Text - " + i });
        }
    }
    public class MyModel {
        public int ID { get; set; }
        public string Text { get; set; }
    }
}