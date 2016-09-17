using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoMvcApp.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            
            return PartialView("_EmployeeList");

        }

        

        public ActionResult EmployeeList([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                List<EmployeeDetailList> _emp = new List<EmployeeDetailList>();
                _emp.Add(new EmployeeDetailList(1, "Bobb", "Ross"));
                _emp.Add(new EmployeeDetailList(2, "Pradeep", "Raj"));
                _emp.Add(new EmployeeDetailList(3, "Arun", "Kumar"));
                DataSourceResult result = _emp.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }
        }

        // GET: Employee
      //  [HttpGet]
        public ActionResult GetAllEmployee([DataSourceRequest]DataSourceRequest request)
        {
            try { 

            var employee = db.Employees.ToList();

            return Json(employee.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public ActionResult UpdateEmployee([DataSourceRequest]DataSourceRequest request, Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new[] { emp}.ToDataSourceResult(request,ModelState));

                }
                else
                {
                    return Json(db.Employees.ToList());
                }
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult AddEmployee([DataSourceRequest]DataSourceRequest request, Employee emp)
        {
            try { 
            if (ModelState.IsValid)
            {

                db.Employees.Add(emp);
                db.SaveChanges();
                    var _emplist = db.Employees.ToList();
               return Json(new[] { emp}.ToDataSourceResult(request,ModelState));
            }

            else
            { 
            return Json(db.Employees.ToList());
            }
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult DeleteEmployee([DataSourceRequest]DataSourceRequest request,Employee emp)
        {
            try
            { 
            Employee employee = db.Employees.Find(emp.EmployeeID);
            if (employee == null)
            {
                return Json("Employee Not Found");
            }

            db.Employees.Remove(employee);
            db.SaveChanges();
            return Json(db.Employees.ToList());
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }

}