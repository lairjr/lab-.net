using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFileUpload.Startup))]
namespace MVCFileUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
