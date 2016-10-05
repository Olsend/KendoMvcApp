using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoMvcApp.Models;

namespace KendoMvcApp.Controllers
{
    public class CascadingCountryController : Controller
    {

        private  EmployeeEntities1 db = new EmployeeEntities1();
        
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCountryList()
        {
            return Json(db.tbl_country.Select(x => new { Country_ID = x.Country_ID, Country_Name = x.Country_Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStateList(int? Country)
        {
            var State = db.tbl_state.AsQueryable();
            if (Country>0)
            {
                
                State = State.Where(s => s.Country_ID == Country);
                return Json(State.Select(s => new { State_ID = s.State_ID, State_Name = s.State_Name }), JsonRequestBehavior.AllowGet);
            }
            else
            return Json(db.tbl_state.Select(s => new { State_ID = s.State_ID, State_Name = s.State_Name }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCityList(int? State)
        {
            var City = db.tbl_city.AsQueryable();
            if(State>0)
            {
                City = City.Where(c => c.State_ID == State);
                return Json(City.Select(c => new { City_ID = c.City_ID, City_Name = c.City_Name }), JsonRequestBehavior.AllowGet);
            }
            else
            { 
            return Json(db.tbl_city.Select(c => new { City_ID = c.City_ID, City_Name = c.City_Name }), JsonRequestBehavior.AllowGet);
            }
        }
    }
}