using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult Index()
        {
            int messageCount = context.Tbl_Message.Count();
            int messageCountIsReadByTrue=context.Tbl_Message.Where(x=>x.IsRead==true).Count();
            int messageCountIsReadByFalse = context.Tbl_Message.Where(x => x.IsRead == false).Count();
            int skillCount=context.Tbl_Skill.Count();
            var totalSkillValue = context.Tbl_Skill.Sum(x => x.Value);
            var averageSkillValue=context.Tbl_Skill.Average(x => x.Value);
            var getEmailFromProfile=context.Tbl_Profile.Select(x=>x.Email).FirstOrDefault();
            var getLastCategoryId = context.Tbl_Category.Max(x => x.CategoryID);
            var getLastCategoryName = context.Tbl_Category.Where(x => x.CategoryID==getLastCategoryId).Select(y=>y.CategoryName).FirstOrDefault();


            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadByTrue = messageCountIsReadByTrue;
            ViewBag.messageCountIsReadByFalse = messageCountIsReadByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.averageSkillValue = averageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategorName = getLastCategoryName;

            return View();
        }
    }
}