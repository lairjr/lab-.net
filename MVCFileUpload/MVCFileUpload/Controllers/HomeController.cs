using MVCFileUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Complex()
        {
            return View();
        }

        public ActionResult MultiInputs()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var result = this.SaveFile(Request.Files[0]);

            return RedirectToAction("Index");
        }

        public ActionResult ComplexUpload(UploadModel model)
        {
            var result = this.SaveFile(model.FileUpload);

            return RedirectToAction("Index");
        }

        public ActionResult MultiFileUpload(MultiFileModel model)
        {
            foreach (var fileItem in model.Items)
            {
                var result = SaveFile(fileItem.File);
            }

            return RedirectToAction("Index");
        }

        public bool SaveFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                file.SaveAs(path);
                return true;
            }
            return false;
        }

    }
}