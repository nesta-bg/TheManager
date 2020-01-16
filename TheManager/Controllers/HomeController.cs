using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheManager.Models;
using TheManager.ViewModels;

namespace TheManager.Controllers
{
    //Controller and Action names. It really doesn't matter when we use attribute routes.
    //public class WelcomeController : Controller

    //[Route("Home")]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        //[Route("Index")]
        //[Route("[action]")]
        [Route("~/")]
        [Route("~/Home")]
        //public ViewResult List()
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            //when we change the name of the action
            //return View("~/Views/Home/Index.cshtml" ,model);
            return View(model);
        }

        //[Route("Home/Details/{id?}")]
        //[Route("Details/{id?}")]
        //[Route("[action]/{id?}")]
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                // If "id" is null use 1, else use the value passed from the route
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}
