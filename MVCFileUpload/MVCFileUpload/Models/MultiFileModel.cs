using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFileUpload.Models
{
    public class MultiFileModel
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public IEnumerable<MultiFileItemModel> Items { get; set; }
    }
}