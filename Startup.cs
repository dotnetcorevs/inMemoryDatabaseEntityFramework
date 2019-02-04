using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
 using Microsoft.EntityFrameworkCore;
 using inDb.Models;

namespace inDb
{
    public class Startup
    {    private static void AddTestData(ApiContext context)
            {
                        var testUser1 = new Models.user
                        {
                             Id = "abc123",
                            FirstName = "Luke",
                            LastName = "Skywalker"
                        };

                            context.Users.Add(testUser1);

                        var testPost1 = new Models.post
                        {
                            Id = "def234",
                            UserId = testUser1.Id,
                            Content = "What a piece of junk!"
                        };

                        context.Posts.Add(testPost1);

                        context.SaveChanges();
            }

        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
             // services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase());
                services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

                services.AddMvc();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
           
                             var context = serviceProvider.GetService<ApiContext>();
                             AddTestData(context);
                             app.UseMvc();
        }
    }
}
