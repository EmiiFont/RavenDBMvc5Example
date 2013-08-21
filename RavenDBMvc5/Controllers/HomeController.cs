using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.DataLayer;
using RavenDBMvc5.Core.Entities;

namespace MongoDBMvc5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        public HomeController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public ActionResult Index()
        {
            var item = new Items
                       {
                           Id = 1,
                           Name = "Bread",
                           Price = "1.00",
                           CreationDate = DateTime.Now,
                           LastUpdateTime = DateTime.Now,
                       };
            _itemService.StoreOrUpdate(item);
            return View(_itemService.GetAllItems().ToList());
        }

        [HttpPost]
        public ActionResult SaveData(Items item)
        {
            return Json(_itemService.StoreOrUpdate(item).Id);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}