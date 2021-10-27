using System.Collections.Generic;
using System.Threading.Tasks;
using RFE.Service.FT.Core.Models.Features;

namespace RFE.Service.FT.Core.Interfaces.Services.Features
{
    /// <summary>
    /// IFeatureService
    /// </summary>
    public interface IFeatureService
    {
        #region Methods

        /// <summary>
        /// GetFeatures
        /// </summary>
        /// <param name="featureGetRequest"></param>
        /// <returns></returns>
        Task<IEnumerable<FeatureGetResponse>> GetFeatures(FeatureGetRequest featureGetRequest);        

        /// <summary>
        /// CreateFeature
        /// </summary>
        /// <param name="featureCreateRequest"></param>
        /// <returns></returns>
        Task<FeatureCreateResponse> CreateFeature(FeatureCreateRequest featureCreateRequest);

        /// <summary>
        /// DeleteFeature
        /// </summary>
        /// <param name="featureDeleteRequest"></param>
        /// <returns></returns>
        Task<FeatureDeleteResponse> DeleteFeature(FeatureDeleteRequest featureDeleteRequest);
       
        /// <summary>
        /// UpdateFeature
        /// </summary>
        /// <param name="featureUpdateRequest"></param>
        /// <returns></returns>
        Task<FeatureUpdateResponse> UpdateFeature(FeatureUpdateRequest featureUpdateRequest);    
            
        #endregion
                                   
    }
}