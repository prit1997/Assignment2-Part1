using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment2_Part1.Startup))]
namespace Assignment2_Part1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
