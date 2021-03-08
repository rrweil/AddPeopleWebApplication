using HW3._3._21_AddPeopleWebApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HW3._3._21_AddPeopleWebApplication.Data;

namespace HW3._3._21_AddPeopleWebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=AddPeopleWebApplication;Integrated Security=true;";


        public IActionResult Index()
        {
            var db = new PersonDb(_connectionString);
            var vm = new IndexViewModel()
            {
                People = db.GetPeople()
            };

            if (TempData["successmessage"] != null)
            {
                vm.SuccessMessage = TempData["successmessage"].ToString();
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {

            var db = new PersonDb(_connectionString);
            var peopleAdded = 0;
            foreach (Person p in people)
            {
                if (p.FirstName != null && p.LastName != null)
                {
                    db.AddPerson(p);
                    peopleAdded++;
                }

            }

            if (peopleAdded > 1)
            {
                TempData["successmessage"] = $"People were added successfully!";
            } else if (peopleAdded > 0)
            {
                TempData["successmessage"] = $"Person was added successfully!";
            }
            return Redirect("/");
        }


        public IActionResult AddPeople()
        {
            return View();
        }
    }
}
