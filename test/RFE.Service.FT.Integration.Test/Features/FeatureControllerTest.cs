using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using IAZI.Common.Test.IntegrationAndComponents.Models;
using RFE.Service.FT.Core.Models.Features;
using RFE.Service.FT.Integration.Test.Shared;
using Xunit;
using Xunit.Abstractions;

namespace RFE.Service.FT.Integration.Test.Features
{
    /// <summary>
    /// Testing Feature Controller logic
    /// </summary>
    public class FeatureControllerTest : ServiceControllerTestBase, IClassFixture<TestWebApplicationFactory>
    {
        #region Properties


        #endregion

       #region Constructor
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputHelper"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public FeatureControllerTest(ITestOutputHelper outputHelper, TestWebApplicationFactory factory) : base(outputHelper, factory)
        {
        }
    
        #endregion

        #region Public methods 

        [Theory]
        [InlineData(HttpStatusCode.Forbidden, "v1/features")]
        [InlineData(HttpStatusCode.OK, "v1/features?productId={productId}")]
        [InlineData(HttpStatusCode.BadRequest, "v1/features?productId=0")]
        public async Task SERAUTHADM17_GetFeatures(HttpStatusCode expectedHttpStatusCode, string url)
        {
            // Arrange 
            url = InitTestUserAndUrl(new TestSetup(expectedHttpStatusCode, url)
            {
                UrlKeyValueMapper = new Dictionary<string, object>
                {
                    {"{productId}", 1}
                }
            });
                       
            // Act            
            var response = await GetHttpClientForSUT().GetAsync(url);

            // Assert
            var responseData = await HandleUrlCallResponse<IEnumerable<FeatureGetResponse>>(response, expectedHttpStatusCode);
        }
        
        #endregion
    }
}