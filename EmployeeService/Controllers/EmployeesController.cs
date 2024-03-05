using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (HRDBContext dbContex = new HRDBContext())
            {
                return dbContex.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (HRDBContext dbContex = new HRDBContext())
            {
                return dbContex.Employees.FirstOrDefault(e => e.id == id);
            }
        }
    }
}
