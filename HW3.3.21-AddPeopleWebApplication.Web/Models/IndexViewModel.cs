using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW3._3._21_AddPeopleWebApplication.Data;

namespace HW3._3._21_AddPeopleWebApplication.Web.Models
{
    public class IndexViewModel
    {
        public List<Person> People { get; set; }
        public string SuccessMessage { get; set; }
    }
}
