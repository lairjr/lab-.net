using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFileUpload.Models
{
    public class UploadModel
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public HttpPostedFileBase  FileUpload { get; set; }
    }
}