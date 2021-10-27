using System;
using System.Data;
using Dapper;
using IAZI.Common.Core.Infrastructure.Interfaces.Data.Repositories.Dapper;
using IAZI.Common.Infrastructure.Data.Repositories.Dapper;
using RFE.Service.FT.Core.Models.Shared;

namespace RFE.Service.FT.Infrastructure.Repositories.Shared
{
    public abstract class AuthAdminRepositoryBase : RepositoryDapperBase
    {
         #region Constants        
             
         #endregion
         
         #region Constructor

       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public AuthAdminRepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
            
        #endregion

        #region Protected methods

        /// <summary>
        /// Default parameters for Stored Procedure calls of AuthAdminService
        /// </summary>
        /// <returns></returns>
        protected DynamicParameters CreateAuthAdminDefaultParameters(RequestBase requestBase)        
        {
            if (requestBase is null)
            {
                throw new ArgumentNullException(nameof(requestBase));
            }

            var parameters = CreateDefaultParameters();
            parameters.Add("@customerId", requestBase.RequestCustomerId, dbType: DbType.Int32);
            parameters.Add("@employeeId", requestBase.RequestUserId, dbType: DbType.Int32);            
            parameters.Add("@culture", requestBase.Culture, dbType: DbType.String, size: 5); 
            return parameters;
        }     

        #endregion
    }
}