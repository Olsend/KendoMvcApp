using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoMvcApp.Controllers
{
    public class GridDataSourceController : Controller
    {
        // GET: GridDataSource
        private EmployeeEntities db = new EmployeeEntities();
        public ActionResult CompanyList()
        {
            return View();
        }
        public ActionResult GetAllEmployeeA([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var employee = db.EmployeeAs.ToList();

                return Json(employee.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public ActionResult GetAllEmployeeB([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var employee = db.EmployeeBs.ToList();

                return Json(employee.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}