using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicDatabase.Startup))]
namespace MusicDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
