using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediTrack.Startup))]
namespace MediTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
