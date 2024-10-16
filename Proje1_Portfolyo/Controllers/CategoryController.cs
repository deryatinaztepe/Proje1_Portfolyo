using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class CategoryController : Controller
    {
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult CategoryList()
        {
            var values = context.Tbl_Category.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            var values = context.Tbl_Category.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult CreateCategory(Tbl_Category category)
        {
            context.Tbl_Category.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Tbl_Category.Find(id);
            context.Tbl_Category.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Tbl_Category.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Category category)
        {
            var value = context.Tbl_Category.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            value.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        
    }
}