using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUpload.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult EditorList(string modelName, string propertyName, int limit)
        {
            var fieldNames = new List<string>();

            for (int count = 0; count < limit; count++)
            {
                var fieldName = modelName + "[" + count + "]." + propertyName;

                fieldNames.Add(fieldName);
            }

            return PartialView("~/Views/Document/FileList.cshtml", fieldNames);
        }
    }
}