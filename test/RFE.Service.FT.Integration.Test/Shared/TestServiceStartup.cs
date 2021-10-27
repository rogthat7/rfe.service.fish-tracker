using System;
using RFE.Service.FT.Web;
using RFE.Service.FT.Web.Controllers.V1.Features;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RFE.Service.FT.Integration.Test.Shared
{
    public class TestServiceStartup : Startup
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public TestServiceStartup(IConfiguration configuration, IWebHostEnvironment env)
            : base(configuration, env)
        {
        }

        #endregion

        #region Protected methods

        protected override void InitIoC(IServiceCollection services)
        {
            base.InitIoC(services);
          
        }            

        protected override IMvcBuilder InitMVC(IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var mvcBuilder = base.InitMVC(services);
            
            // Add any controller from web project here
            mvcBuilder.AddApplicationPart(typeof(FeatureController).Assembly);         
            
            return mvcBuilder;
        }
            
        #endregion
    }
}