using StoreInventory.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreInventory.Controllers
{
    public class HomeController : Controller
    {

       private IDataManager _DataManager;

        public HomeController(IDataManager _dataManager)
        {

            _DataManager = _dataManager;
        }


    
        public ActionResult Index()
        {
           
            return View();
        }

    

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}