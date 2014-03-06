using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebFunctionality.Startup))]
namespace TestWebFunctionality
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
