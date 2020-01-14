using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheManager.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index() {
            return Json(new { id = 1, name = "Nenad" }); 
        }
    }
}
