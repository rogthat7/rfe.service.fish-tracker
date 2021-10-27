using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using IAZI.Common.Service.Web.Providers;
using IAZI.Common.Core.Models.Auth;

namespace RFE.Service.FT.Core.Models.Shared
{
    /// <summary>
    /// RequestBase for all endpoints
    /// </summary>
    public abstract class RequestBase
    {
        #region Constants

        /// <summary>
        /// Name of custom request header to provide the request user Id
        /// </summary>
        private const string XUserIdRequestHeader = "X-UserId"; 

        /// <summary>
        /// Name of custom request header to provide the request customer Id
        /// </summary>
        private const string XCustomerIdRequestHeader = "X-CustomerId"; 
            
        #endregion
        
        #region Properties

        /// <summary>
        /// Culture
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(5)]
        [DefaultValue(DefaultValues.DefaultCulture)]
        [FromHeader(Name = IAZIHeader.XCultureRequestHeader)]
        public string Culture { get; set; } = DefaultValues.DefaultCulture;

        /// <summary>
        /// EmployeeId
        /// </summary>
        /// <value></value>        
        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue(DefaultValues.DefaultRequestUserId)]
        [FromHeader(Name = XUserIdRequestHeader)]
        public int? RequestUserId { get; set; } = DefaultValues.DefaultRequestUserId;

        /// <summary>
        /// CustomerId
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue(DefaultValues.DefaultRequestCustomerId)]
        [FromHeader(Name = XCustomerIdRequestHeader)]
        public int? RequestCustomerId { get; set; } = DefaultValues.DefaultRequestCustomerId;          
        #endregion
    }
}