using MVCFileUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
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
            var test = new TestName();

            test.PName = new Test();

            var name = GetMemberName<TestName>(_ => _.PName.MultiFile);

            return View();
        }

        public ActionResult Ajax()
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

        [HttpPost]
        public JsonResult AjaxUpload(UploadModel model)
        {
            var result = this.SaveFile(model.FileUpload);

            var jsonResult = new JsonResult();
            jsonResult.Data = new { Status = "Ok" };
            return jsonResult;
        }

        [HttpPost]
        public ActionResult AjaxUploadIFrame(MultiFileModel model)
        {
            foreach (var fileItem in model.Items)
            {
                var result = SaveFile(fileItem.File);
            }

            return CreateContentResultForDocument();
        }

        private ContentResult CreateContentResultForDocument()
        {
            var contentResult = new ContentResult();

            var contentStringBuilder = new StringBuilder();
            contentStringBuilder.Append(@"<textarea id='dataJsonResponse' data-type='application/json'>");
            contentStringBuilder.Append(@"{'ok': 'false'");
            contentStringBuilder.Append(@"</textarea>");

            contentResult.Content = contentStringBuilder.ToString();

            return contentResult;
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

        public string GetPropertyName(Expression<Func<object>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }

        public static MemberInfo GetMember<T>(Expression<Func<T, object>> property)
        {
            var expression = (MemberExpression)property.Body;
            return expression.Member;
        }

        public static string GetMemberName<T>(Expression<Func<T, object>> property)
        {
            return GetMember(property).Name;
        }
    }

    public class Test
    {
        public MultiFileModel MultiFile { get; set; }

        public string PropertyName
        {
            get
            {
                Expression<Func<object>> expression = () => this.MultiFile;
                MemberExpression body = (MemberExpression)expression.Body;
                return body.Member.Name;
            }
        }
    }

    public static class MemberOf<TSource> where TSource : class
    {
        public static string Name<T>(Expression<Func<TSource, T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                return ((MemberExpression)expression.Body).Member.Name;
            }
            return string.Empty;
        }
    }

    public class TestName
    {
        public Test PName { get; set; }
    }
}