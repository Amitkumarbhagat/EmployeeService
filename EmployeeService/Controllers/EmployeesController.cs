using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{

    // Get : api/Employees
    public class EmployeesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<Employee> employees = new List<Employee>();
            using (HRDBContext dbContex = new HRDBContext())
            {
                employees = dbContex.Employees.ToList();
                if (employees.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again later");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employees);
                }
            }
        }

        //public IEnumerable<Employee> Get()
        //{
        //    using (HRDBContext dbContex = new HRDBContext())
        //    {
        //        return dbContex.Employees.ToList();
        //    }
        //}

        public HttpResponseMessage Get(int id)
        {
            using (HRDBContext dbContex = new HRDBContext())
            {
                var emp = dbContex.Employees.FirstOrDefault((e => e.id == id));
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id" + id + "Not found in our database");
                }
            }
        }
    }
}
