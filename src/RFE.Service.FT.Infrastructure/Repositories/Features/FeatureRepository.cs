using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RFE.Service.FT.Core.Interfaces.Infrastructure.Repositories.Features;
using Dapper;
using IAZI.Common.Core.Models.Data.Repositories.Dapper;
using IAZI.Common.Core.Infrastructure.Interfaces.Data.Repositories.Dapper;
using RFE.Service.FT.Infrastructure.Repositories.Shared;
using IAZI.Common.Infrastructure.Data.Utils.Dapper;
using RFE.Service.FT.Core.Models.Features;

namespace RFE.Service.FT.Infrastructure.Repositories.Features
{
    /// <summary>
    /// Features Repository class
    /// </summary>
    public class FeatureRepository : AuthAdminRepositoryBase, IFeatureRepository
    {
        #region Constants
        
        private const string SprFeatureGet = "[AUTH].[FeatureGet]";
        private const string SprFeatureCreate = "[AUTH].[FeatureCreate]";
        private const string SprFeatureDelete = "[AUTH].[FeatureDelete]";        
        private const string SprFeatureUpdate = "[AUTH].[FeatureUpdate]";        

        #endregion

        #region Constructor

       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public FeatureRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
            
        #endregion

        #region Public methods

        /// <summary>
        /// GetFeatures
        /// </summary>
        /// <param name="featureGetRequest"></param>
        /// <returns></returns>
        public async Task<ResponseContainer<IEnumerable<FeatureGetResponse>>> GetFeatures(FeatureGetRequest featureGetRequest)
        {
            if (featureGetRequest is null)
            {
                throw new ArgumentNullException(nameof(featureGetRequest));
            }
           
            var parameters = CreateAuthAdminDefaultParameters(featureGetRequest);
            parameters.Add("@featureId", featureGetRequest.FeatureId, dbType: DbType.Int32);
            parameters.Add("@productId", featureGetRequest.ProductId, dbType: DbType.Int32);
            return  await ExecuteStoredProcedureListResult<FeatureGetResponse>(SprFeatureGet, parameters);
                 
        } 

        /// <summary>
        /// CreateFeature
        /// </summary>
        /// <param name="featureCreateRequest"></param>
        /// <returns></returns>
        public async Task<ResponseContainer<FeatureCreateResponse>> CreateFeature(FeatureCreateRequest featureCreateRequest)
        {
            if (featureCreateRequest is null)
            {
                throw new ArgumentNullException(nameof(featureCreateRequest));
            }
            
            var parameters = CreateAuthAdminDefaultParameters(featureCreateRequest);
            parameters.Add("@externalId", featureCreateRequest.ExternalId, dbType: DbType.String, size: 200);
            parameters.Add("@productId", featureCreateRequest.ProductId, dbType: DbType.Int32);
            return await ExecuteStoredProcedureCreateResult<FeatureCreateResponse>(SprFeatureCreate, parameters);
        }

        /// <summary>
        /// DeleteFeature
        /// </summary>
        /// <param name="featureDeleteRequest"></param>
        /// <returns></returns>
        public async Task<ResponseContainer<FeatureDeleteResponse>> DeleteFeature(FeatureDeleteRequest featureDeleteRequest)
        {
            if (featureDeleteRequest is null)
            {
                throw new ArgumentNullException(nameof(featureDeleteRequest));
            }

            var parameters = CreateAuthAdminDefaultParameters(featureDeleteRequest);
            parameters.Add("@featureId", featureDeleteRequest.FeatureId, dbType: DbType.Int32);
            parameters.Add("@archive", featureDeleteRequest.Archive, dbType: DbType.Boolean);            

            return await ExecuteStoredProcedureUpdateDeleteResult<FeatureDeleteResponse>(SprFeatureDelete, parameters);
        }

        /// <summary>
        /// Update feature data
        /// </summary>
        /// <param name="featureDataUpdateRequest"></param>
        /// <returns></returns>
        public async Task<ResponseContainer<FeatureUpdateResponse>> UpdateFeature(FeatureUpdateRequest featureUpdateRequest)
        {
            if (featureUpdateRequest is null)
            {
                throw new ArgumentNullException(nameof(featureUpdateRequest));
            }

            if (featureUpdateRequest.Attributes is null)
            {
                throw new ArgumentNullException(nameof(featureUpdateRequest.Attributes));
            }

            var attributesDataTable = DataTableConverter.ConvertToDataTable(featureUpdateRequest.Attributes);

            var parameters = CreateAuthAdminDefaultParameters(featureUpdateRequest);
            parameters.Add("@featureId", featureUpdateRequest.FeatureId, dbType: DbType.Int32);
            parameters.Add("@table", attributesDataTable.AsTableValuedParameter(UserTableTypeAttributesIn));
            return await ExecuteStoredProcedureUpdateDeleteResult<FeatureUpdateResponse>(SprFeatureUpdate, parameters); 
        }        

        #endregion
    }
}