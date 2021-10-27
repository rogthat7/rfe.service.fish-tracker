using System;
using IAZI.Common.Core.Models.Web.Options;

namespace RFE.Service.FT.Core.Models.Options
{
    public class MyOptions : CustomOptions
    {
        #region Properties

        public string CustomParameter1 { get; set; }
        
        #endregion

        #region Methods

         /// <summary>
        /// Is used to validate the settings when options are constructed
        /// </summary>
        public static bool ValidateSettings(MyOptions options)
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