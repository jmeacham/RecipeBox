using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeBox.Startup))]
namespace RecipeBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
