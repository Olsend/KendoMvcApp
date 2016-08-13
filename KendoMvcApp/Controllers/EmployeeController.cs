using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }
        public ActionResult EmployeeList([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                List<Employee> _emp = new List<Employee>();
                _emp.Add(new Employee(1, "Bobb", "Ross"));
                _emp.Add(new Employee(2, "Pradeep", "Raj"));
                _emp.Add(new Employee(3, "Arun", "Kumar"));
                DataSourceResult result = _emp.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
    }

}