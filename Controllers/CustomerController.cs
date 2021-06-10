using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutorial7ADO.DataAccess;
using Tutorial7ADO.Models;

namespace Tutorial7ADO.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }

        DataAccessLayer objItem;

        [HttpPost, HandleError]
        public JsonResult SaveInsertData(CustomerDBModel _dbModel)
        {
            int _result = 0;
            objItem = new DataAccessLayer();
            _result = objItem.InsertData(_dbModel);
            if (_result > 0)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }

        [HttpGet]
        public JsonResult SelectAllData()
        {
            objItem = new DataAccessLayer();
            CustomerDBModel _dbModelList = new CustomerDBModel();
            _dbModelList.ShowallCustomer = objItem.SelectAllData();
            return this.Json(_dbModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SelectDatabyID(CustomerDBModel _dbModel)
        {
            objItem = new DataAccessLayer();
            CustomerDBModel _dbModelList = new CustomerDBModel();
            _dbModelList = objItem.SelectDatabyID(_dbModel);
            return this.Json(_dbModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteData(CustomerDBModel _dbModel)
        {
            int _result = 0;
            objItem = new DataAccessLayer();
            _result = objItem.DeleteData(_dbModel);
            if (_result > 0)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
    }
}