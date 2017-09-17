namespace nancy_test
{
    using System.ComponentModel;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Nancy.Owin;

    public class Startup
    {
        private IContainer container {get;set;}

        public Startup()
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}
