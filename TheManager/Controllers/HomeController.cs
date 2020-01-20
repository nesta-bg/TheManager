using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheManager.Models;
using TheManager.ViewModels;

namespace TheManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

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

        //https://localhost:44374/home/details/2
        //https://localhost:44374/home/details/2?name=manager
        //https://localhost:44374/home/details/2?name=manager&id=5
        //https://localhost:44374/home/details?name=manager&id=5
        //public string Details(int? id, string name)
        //{
        //    return "id = " + id.Value.ToString() + " name = " + name; 
        //}

        [HttpGet]
        public ViewResult Create() {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Employee employee)
        {
            Employee newEmployee = _employeeRepository.Add(employee);
            return RedirectToAction("details", new { id = newEmployee.Id });
        }
    }
}
