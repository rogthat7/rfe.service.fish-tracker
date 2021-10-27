using System;
using RFE.Service.FT.Core.Models.Options;

namespace RFE.Service.FT.Acceptance.Test.Models.Options
{
    public class TestOptions : MyOptions
    {
        #region Properties

        public TestConfigOptions Test { get; set; } = new TestConfigOptions();
       
        #endregion

         #region Methods       

        /// <summary>
        /// Is used to validate the settings when options are constructed
        /// </summary>
        public static bool ValidateSettings(TestOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }   

            return TestConfigOptions.ValidateSettings(options.Test) ? MyOptions.ValidateSettings(options) : false;
        }

        #endregion
    } 
}