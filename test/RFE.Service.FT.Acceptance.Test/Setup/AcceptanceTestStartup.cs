using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using IAZI.Common.Core.Models.Web.Options;
using IAZI.Common.Test.Acceptance.Shared;
using RFE.Service.FT.Acceptance.Test.Models.Options;
using RFE.Service.FT.Acceptance.Test.Shared.Models.Settings;
using RFE.Service.FT.Web;

namespace RFE.Service.FT.Acceptance.Test.Setup
{
    public class AcceptanceTestStartup : AcceptanceTestStartupBase<Startup, TestOptions, TestSettings, TestSecretSettings>
    {
        #region Properties      
        
        #endregion

        #region Constructor

        public AcceptanceTestStartup(IWebHostEnvironment env, IConfiguration config)
            : base(env, config)
        {            
        }

        #endregion

        #region Protected methods                       

        protected override void ApplyTestSettings(TestSettings testSettings, TestSecretSettings testSecretSettings, CustomServiceOptions<TestOptions> config)
        {
            //Acceptance Test testsettings string for local execution of tests
            
            //Acceptance Test testsettings string for execution of tests on Teamcity via env variable

            // TODO: Right now there's only one property that can be set either directly in the testsettings.json or need to be provided via Teamcity environment variable
            var password = config.Security.ApiSecret;
            if (!string.IsNullOrEmpty(password))
            {
                return;
            }

            // Provided by Teamcity / Environment variable

            if (testSecretSettings == null)
            {
                throw new Exception($"Please provide test secret settings for this environment");
            }
           
            if (string.IsNullOrEmpty(testSecretSettings.TestClientSecret))
            {
                throw new Exception($"Please add TestClientSecret in testSecretSettings!");
            }

            config.Security.ApiSecret = testSecretSettings.TestClientSecret;
        }

        #endregion
    }
}
