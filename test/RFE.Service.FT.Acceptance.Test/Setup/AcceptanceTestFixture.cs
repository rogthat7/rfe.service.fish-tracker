using IAZI.Common.Test.Acceptance.Shared;
using IAZI.Common.Core.Models.Web.Options;

namespace RFE.Service.FT.Acceptance.Test.Setup
{
    public class AcceptanceTestFixture : AcceptanceTestFixtureBase<AcceptanceTestStartup>
    {        
        #region Properties
        
            
        #endregion
        
        #region Constructor

        public AcceptanceTestFixture() : base()
        {              
        }
            
        #endregion

        #region Public Methods
            
        #endregion

        #region Protected Methods

        protected override void InitEnvironment()
        {
            // Protection to deploy _deployEnvironment changed by accident
            #if DEBUG
            
            // Override settings for local testing
            //SutEnvironmentOverride = DeployEnvironment.DEV;

            #endif

            base.InitEnvironment();
        }
        
        #endregion       

        #region Private methods
        
            
        #endregion
    
    }
}