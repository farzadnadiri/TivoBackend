using App.DataLayer.Context;
using App.Entities.Identity;
using App.ViewModels.Identity.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using App.IocConfig;
using DNTCommon.Web.Core;
using App.Services.Contracts.Identity;
using Microsoft.Extensions.Logging;

namespace App.MsTests
{

    [TestClass]
    public class CoreTests
    {
        private readonly IServiceProvider _serviceProvider;
        
        public CoreTests()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddLogging(cfg => cfg.AddConsole().AddDebug());
            services.AddScoped<IWebHostEnvironment, TestHostingEnvironment>();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            services.Configure<SiteSettings>(options => configuration.Bind(options))
                .PostConfigure<SiteSettings>(x => { x.ActiveDatabase = ActiveDatabase.SqlServer; });

            services.Configure<SiteSettings>(options => configuration.Bind(options))
                .PostConfigure<SiteSettings>(x => { x.DataProtectionX509Certificate = new DataProtectionX509Certificate()
                {
                    FileName = "idp.pfx",
                    Password = "123"
                }; });


            services.AddSingleton<IConfigurationRoot>(provider => configuration);
            
            services.AddCustomIdentityServices();
            services.AddDNTCommonWeb();
            services.AddCloudscribePagination();

            var siteSettings = services.GetSiteSettings();
            services.AddConfiguredDbContext(siteSettings);
            _serviceProvider = services.BuildServiceProvider();

            var identityDbInitialize = _serviceProvider.GetRequiredService<IIdentityDbInitializer>();
            identityDbInitialize.Initialize();
            identityDbInitialize.SeedData();


        }

        //[TestMethod]
        //public void Test_UserAdmin_Exists()
        //{
            
        //    _serviceProvider.RunScopedService<IUnitOfWork>(context =>
        //    {
        //        var users = context.Set<User>();
        //        Assert.IsTrue(users.Any(x => x.UserName == "Admin"));
        //    });
        //}


        [TestMethod]
        public void Test_Failed()
        {
            Assert.AreEqual(false,false,"hey");
        }


    }
}