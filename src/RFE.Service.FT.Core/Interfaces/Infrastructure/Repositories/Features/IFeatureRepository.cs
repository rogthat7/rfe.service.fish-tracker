using System.Collections.Generic;
using System.Threading.Tasks;
using IAZI.Common.Core.Models.Data.Repositories.Dapper;
using RFE.Service.FT.Core.Models.Features;

namespace RFE.Service.FT.Core.Interfaces.Infrastructure.Repositories.Features
{
    /// <summary>
    /// IFeatureRepository interface
    /// </summary>
    public interface IFeatureRepository
    {
        #region Methods

        /// <summary>
        /// GetFeatures
        /// </summary>
        /// <param name="featureListGetRequest"></param>
        /// <returns></returns>
        Task<ResponseContainer<IEnumerable<FeatureGetResponse>>> GetFeatures(FeatureGetRequest featureListGetRequest);

        /// <summary>
        /// CreateFeature
        /// </summary>
        /// <param name="featureCreateRequest"></param>
        /// <returns></returns>
        Task<ResponseContainer<FeatureCreateResponse>> CreateFeature(FeatureCreateRequest featureCreateRequest);
        
        /// <summary>
        /// DeleteFeature
        /// </summary>
        /// <param name="featureDeleteRequest"></param>
        /// <returns></returns>
        Task<ResponseContainer<FeatureDeleteResponse>> DeleteFeature(FeatureDeleteRequest featureDeleteRequest);                
        
        /// <summary>
        /// UpdateFeature
        /// </summary>
        /// <param name="featureUpdateRequest"></param>
        /// <returns></returns>
        Task<ResponseContainer<FeatureUpdateResponse>> UpdateFeature(FeatureUpdateRequest featureUpdateRequest);
            
        #endregion
        
    }
}