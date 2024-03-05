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

        // GET: api/Employees
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



        // GET: api/Employees/id
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

        // POST:

        public HttpResponseMessage Post(Employee employee)
        {
            using (HRDBContext DBContext = new HRDBContext())
            {
                if(employee != null)
                {
                    DBContext.Employees.Add(employee);
                    DBContext.SaveChanges();  // this lin of the code is neede to save the data into db so its important
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide the required information");
                }
            }
        }

        // PUT:
        public HttpResponseMessage Post(int id, Employee employee)
        {
            using (HRDBContext dbContex = new HRDBContext())
            {
                var emp = dbContex.Employees.FirstOrDefault(e => e.id == id);
                if (emp != null)
                {
                    emp.id = employee.id;
                    emp.firstname = employee.firstname;
                    emp.lastName = employee.lastName;
                    emp.Email = employee.Gender;
                    emp.city = employee.city;

                    dbContex.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id" + id + "Not found in our database");
                }
            }


        }

        //Delete:

        public HttpResponseMessage Delete(int id)
        {
            using (HRDBContext dbContex = new HRDBContext())
            {
                var emp = dbContex.Employees.FirstOrDefault((e => e.id == id));
                if (emp != null)
                {
                    dbContex.Employees.Remove(emp);
                    dbContex.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id" + id + "Not found in our database");
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

    }
}
