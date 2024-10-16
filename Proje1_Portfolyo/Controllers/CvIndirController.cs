using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class CvIndirController : Controller
    {
        // GET: CvIndir

        public ActionResult CvIndir()
        {
            
            var filePath = Server.MapPath("~/Content/Cv/yeni.pdf");

            
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "yeni.pdf";
            var contentType = "Cv/yeni.pdf";

           
            return File(filePath, contentType, fileName);

            //public ActionResult CvIndir(string fileName)
            //{
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "/Content/Cv/yeni.pdf", fileName);

            //    if (!System.IO.File.Exists(filePath))
            //    {
            //        return HttpNotFound("Dosya bulunamadı.");
            //    }

            //    var fileBytes = System.IO.File.ReadAllBytes(filePath);
            //    return File(fileBytes, "/Content/Cv/yeni.pdf", fileName);
            //}
        }
}
}