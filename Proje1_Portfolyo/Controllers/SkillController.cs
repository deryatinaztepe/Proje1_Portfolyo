using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Collections;
using System.Web.Helpers;

namespace Proje1_Portfolyo.Controllers
{
    public class SkillController : Controller
    {
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult SkillList(int sayfa=1)
        {
            //var values=context.Tbl_Skill.ToList();
            var values = context.Tbl_Skill.ToList().ToPagedList(sayfa,5);
            
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var veriler = context.Tbl_Skill.ToList();
            veriler.ToList().ForEach(x => xvalue.Add(x.Title));
            veriler.ToList().ForEach(x => yvalue.Add(x.Value));
            var grafik = new Chart(width:450, height: 500).AddTitle("Yetenekler").AddSeries(chartType: "Pie", name: "Title", xValue: xvalue, yValues: yvalue);

            return View(values);
            //return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Tbl_Skill skill)
        {
            context.Tbl_Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Tbl_Skill.Find(id);
            context.Tbl_Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        
        public ActionResult Chart()
        {
           
            return View();
        }
    }
}