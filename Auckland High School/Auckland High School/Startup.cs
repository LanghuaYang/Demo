using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Auckland_High_School.Startup))]
namespace Auckland_High_School
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
