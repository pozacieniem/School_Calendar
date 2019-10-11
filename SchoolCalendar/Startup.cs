using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolCalendar.Startup))]

namespace SchoolCalendar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public enum Day
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5
    }
}