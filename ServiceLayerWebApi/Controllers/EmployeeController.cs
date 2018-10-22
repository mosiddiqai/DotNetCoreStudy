using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;

namespace ServiceLayerWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:55247/Pages/H_NG_HttpServices.html", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage GetEmployeeList()
        {
            List<Models.EmployeeVM> employees = new List<Models.EmployeeVM>();
            employees.Add(new Models.EmployeeVM() { EmpID = 1, FirstName = "David", LastName = "Hasting", Gender = "Male", Salary = 55000 });
            employees.Add(new Models.EmployeeVM() { EmpID = 1, FirstName = "Peter1", LastName = "Simon", Gender = "Male", Salary = 65000 });

            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        public HttpResponseMessage GetEmployeeById(int id)
        {
            Models.EmployeeVM employee = new Models.EmployeeVM()
            {
                EmpID = id,
                FirstName = "David",
                LastName = "Hasting",
                Gender = "Male",
                Salary = 50000
            };

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

    }
}
