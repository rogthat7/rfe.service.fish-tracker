using IAZI.Common.Core.Models.Web.Options;
using IAZI.Common.Test.Acceptance.Shared;
using RFE.Service.FT.Acceptance.Test.Models.Options;
using RFE.Service.FT.Acceptance.Test.Setup;
using Microsoft.Extensions.Options;
using Xunit;
using Xunit.Abstractions;

namespace RFE.Service.FT.Acceptance.Test.Common
{
    [Collection("AcceptanceTest")]
    public class ServiceAcceptanceTestBase : AcceptanceTestBase<AcceptanceTestStartup>
    {
        #region Constants
        
        #endregion
        
        #region Properties

        private IOptions<CustomServiceOptions<TestOptions>> _testServiceIOptions;
        protected IOptions<CustomServiceOptions<TestOptions>> TestServiceIOptions
        {
            get
            {
                return _testServiceIOptions ?? (_testServiceIOptions = GetService<IOptions<CustomServiceOptions<TestOptions>>>());
            }
        } 

        protected CustomServiceOptions<TestOptions> TestServiceOptions
        {
            get
            {
                return TestServiceIOptions.Value;
            }
        }

        protected TestConfigOptions TestConfigOptions
        {
            get
            {
                return TestServiceOptions.Custom.Test;
            }
        }
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceAcceptanceTestBase(ITestOutputHelper testOutputHelper, AcceptanceTestFixture fixture) : base(testOutputHelper, fixture)
        {
        }
        
        #endregion
        
        #region Public methods
        
        #endregion
        
        #region Protected methods
        
        #endregion
        
        #region Private methods
        
        #endregion
    }
    
}