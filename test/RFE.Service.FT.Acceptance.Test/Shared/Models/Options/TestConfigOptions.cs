using System;

namespace RFE.Service.FT.Acceptance.Test.Models.Options
{   
    public class TestConfigOptions
    {
        #region Properties      
        
        public string UserName { get; set; }

        public string UserNamePassword { get; set; }    
            
        #endregion

         #region Methods

        /// <summary>
        /// Is used to validate the settings when options are constructed
        /// </summary>
        public static bool ValidateSettings(TestConfigOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }   

            return true;
        }

        #endregion
    }
}