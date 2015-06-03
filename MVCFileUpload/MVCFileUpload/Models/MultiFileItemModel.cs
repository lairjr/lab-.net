using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFileUpload.Models
{
    public class MultiFileItemModel
    {
        public string FileName { get; set; }
        public HttpPostedFileBase  File { get; set; }
    }
}