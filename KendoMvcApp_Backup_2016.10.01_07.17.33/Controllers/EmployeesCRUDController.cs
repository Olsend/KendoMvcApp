using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KendoMvcApp.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace KendoMvcApp.Controllers
{
    public class EmployeesCRUDController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: EmployeesCRUD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllEmployee([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var employee = db.Employees.ToList();

                return Json(employee.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
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
                    return Json(new[] { emp }.ToDataSourceResult(request, ModelState),JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(db.Employees.ToList(),JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult AddEmployee([DataSourceRequest]DataSourceRequest request, Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Employees.Add(emp);
                    db.SaveChanges();
                    var _emplist = db.Employees.ToList();
                    return Json(new[] { emp }.ToDataSourceResult(request, ModelState),JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json(db.Employees.ToList(),JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult DeleteEmployee([DataSourceRequest]DataSourceRequest request, Employee emp)
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
                return Json(db.Employees.ToList(),JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
