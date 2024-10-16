using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class MessageController : Controller
    {
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult Inbox()
        {
            var values=context.Tbl_Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value=context.Tbl_Message.Where(x=>x.MessageID == id).FirstOrDefault();
            value.IsRead= true;
            context.SaveChanges();
            return View(value);
        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Tbl_Message.Where(x => x.MessageID == id).FirstOrDefault();
            value.IsRead= true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Tbl_Message.Where(x => x.MessageID == id).FirstOrDefault();
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Tbl_Message.Find(id);
            context.Tbl_Message.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}