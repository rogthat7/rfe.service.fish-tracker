using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using Xunit;
using Xunit.Abstractions;
using System.Net.Http;
using Microsoft.Extensions.Options;
using IAZI.Common.Core.Models.Web.Options;
using RFE.Service.FT.Core.Models.Options;
using IAZI.Common.Test.IntegrationAndComponents.Shared;
using IAZI.Common.Core.Models.Auth;

namespace RFE.Service.FT.Integration.Test.Shared
{
    // The collection ensures that all Service controller tests are executed sequentially
    // This will avoid issues with e.g. the TestUser singleton that might be manipulated from different tests at the same time
    [Collection("ServiceControllerTests")]
    public abstract class ServiceControllerTestBase : IntegrationAndComponentTestBase<TestServiceStartup>, IClassFixture<TestWebApplicationFactory>
    {
        #region Properties         

        protected IOptions<CustomServiceOptions<MyOptions>> ServiceOptions;       

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public ServiceControllerTestBase(ITestOutputHelper outputHelper, TestWebApplicationFactory factory) : base(outputHelper, factory)
        {
            ServiceOptions = GetService<IOptions<CustomServiceOptions<MyOptions>>>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Dispose method
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Set the Integration Test User
        /// </summary>
        /// <param name="expectedHttpStatusCode"></param>
        protected override void ModifyTestUser(HttpStatusCode expectedHttpStatusCode)
        {     
            if (expectedHttpStatusCode != HttpStatusCode.Unauthorized
                && expectedHttpStatusCode != HttpStatusCode.Forbidden)
            {
                TestUser.UserClaims = new List<Claim>
                                        {
                                            new Claim(IAZIToken.LegacyUserId, "1"),
                                            new Claim(IAZIToken.LegacyEmail, "testuser@iazi.ch")
                                        };

                TestUser.AuthData = null;
            }
            else if (expectedHttpStatusCode != HttpStatusCode.Unauthorized)
            {
                TestUser.UserClaims = new List<Claim>
                                        {
                                            new Claim(IAZIToken.LegacyUserId, "1"),
                                            new Claim(IAZIToken.LegacyEmail, "testuser@iazi.ch")
                                        };
            }                      
        } 

        /// <summary>
        /// sets headers for each request
        /// </summary>
        /// <param name="allowAutoRedirect"></param>
        /// <returns></returns>
        protected override HttpClient GetHttpClientForSUT(bool allowAutoRedirect = true, bool setCustomIpAddress = true)
        {
            var httpClient = base.GetHttpClientForSUT();
            
            return httpClient;
        }
        #endregion
    }
}