using System;
using System.Linq;
using FreeYourFridge.API.Data;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper
{
    public class CustomWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        private readonly InMemoryDatabaseRoot _dbRoot = new InMemoryDatabaseRoot();
        public DatabaseHelper TestingDatabase { get; }

        public CustomWebApplicationFactory()
        {
            TestingDatabase = new DatabaseHelper().GetDefaultDb();
        }


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<DataContext>(options =>
                        {
                            //options.UseInMemoryDatabase(Guid.NewGuid().ToString(), _dbRoot);
                            options.UseInMemoryDatabase("InMemDbTesting", _dbRoot);
                        }, ServiceLifetime.Transient);

                services.AddAuthentication("test")
                    .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>("test",
                        options => options.NameIdentifier = "1");

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<T>>>();
                    db.Database.EnsureCreated();

                    try
                    {
                        new DatabaseHelper().InitialiseDbForTests(db);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "Seeding the database failed. Error{0}", e.Message);
                    }
                }
            });
        }
    }

}
