using System;
using System.Net;
using System.Threading.Tasks;
using IAZI.Common.Test.Traits;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using RFE.Service.FT.Acceptance.Test.Setup;
using RFE.Service.FT.Acceptance.Test.Common;
using RFE.Service.FT.Core.Models.Features;

namespace RFE.Service.FT.Acceptance.Test.Controllers.Features
{
    public class FeatureControllerTest : ServiceAcceptanceTestBase
    {
        #region Constants
    
        #endregion
    
        #region Properties
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputHelper"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public FeatureControllerTest(ITestOutputHelper outputHelper, AcceptanceTestFixture fixture) : base(outputHelper, fixture)
        {          
        }
    
        #endregion
    
        #region Public methods            

        [Theory]        
        [InlineData(HttpStatusCode.OK, "v1/features?productId={productId}")]        
        [Environment("DEV")]
        public async Task SERAUTHADM17_GetFeatures(HttpStatusCode expectedHttpStatusCode, string url)
        {
            // Arrange 
            url = InitTestUrl(url, new Dictionary<string, object>
                {
                    {"{productId}", 1}
                });
                       
            // Act            
            var httpClient = await GetHttpClientWithAccessToken("Service.Template", true, false, TestConfigOptions.UserName, TestConfigOptions.UserNamePassword);
            var response = await httpClient.GetAsync(url);   

            // Assert
            var responseData = await HandleUrlCallResponse<IEnumerable<FeatureGetResponse>>(response, expectedHttpStatusCode);            
        }
    
        #endregion
            
    }    
}