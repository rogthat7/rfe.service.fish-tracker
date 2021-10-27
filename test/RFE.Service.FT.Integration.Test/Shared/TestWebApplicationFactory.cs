using System;
using Microsoft.Extensions.Options;
using IAZI.Common.Core.Models.Web.Options;
using RFE.Service.FT.Core.Models.Options;
using IAZI.Common.Test.IntegrationAndComponents.Shared;
using IAZI.Common.Core.Models.Utils;

namespace RFE.Service.FT.Integration.Test.Shared
{
    public class TestWebApplicationFactory : TestWebApplicationFactoryBase<TestServiceStartup>, IDisposable
    {
        #region Properties

        public override string Environment
        {
            get
            {
                return ApplicationInfo.EnvironmentTesting;
            }
        }

        #endregion

        #region Constructor  
      
        public TestWebApplicationFactory() : base(overrideContentRootPathUseCurrentDirectory: true)
        {
            var serviceConfiguration = Services.GetService(typeof(IOptions<CustomServiceOptions<MyOptions>>)) as IOptions<CustomServiceOptions<MyOptions>>;           
        }

        #endregion

        #region Public methods    
       
        #endregion

        #region Protected methods


        #endregion
    }
}