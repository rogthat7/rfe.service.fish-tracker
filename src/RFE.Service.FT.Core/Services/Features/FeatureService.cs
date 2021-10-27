using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IAZI.Common.Core.Models.Web.Options;
using RFE.Service.FT.Core.Interfaces.Infrastructure.Repositories.Features;
using RFE.Service.FT.Core.Interfaces.Services.Features;
using RFE.Service.FT.Core.Models.Features;
using RFE.Service.FT.Core.Models.Options;
using Microsoft.Extensions.Options;

namespace RFE.Service.FT.Core.Services.Features
{
    /// <summary>
    /// Implementation of IFeatureService
    /// </summary>
    public class FeatureService : IFeatureService
    {
        #region Properties

        private readonly IFeatureRepository _featureRepository;

        private readonly CustomServiceOptions<MyOptions> _serviceOptions;
            
        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="featureRepository"></param>
        public FeatureService(IOptions<CustomServiceOptions<MyOptions>> serviceOptions, IFeatureRepository featureRepository)
        {
            _serviceOptions = serviceOptions?.Value ?? throw new ArgumentNullException(nameof(serviceOptions));
            _featureRepository = featureRepository ?? throw new ArgumentNullException(nameof(featureRepository));
        }
            
        #endregion

        #region Public methods

        /// <summary>
        /// Features Get
        /// </summary>
        /// <param name="featureGetRequest"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FeatureGetResponse>> GetFeatures(FeatureGetRequest featureGetRequest)
        {
            if (featureGetRequest is null)
            {
                throw new ArgumentNullException(nameof(featureGetRequest));
            }

            return (await _featureRepository.GetFeatures(featureGetRequest)).ValidateResponseContainer().Response;            
        }

        /// <summary>
        /// Features Create
        /// </summary>
        /// <param name="featureCreateRequest"></param>
        /// <returns></returns>
        public async Task<FeatureCreateResponse> CreateFeature(FeatureCreateRequest featureCreateRequest)
        {
            if (featureCreateRequest is null)
            {
                throw new ArgumentNullException(nameof(featureCreateRequest));
            }

            return (await _featureRepository.CreateFeature(featureCreateRequest)).ValidateResponseContainer().Response;               
        }

        /// <summary>
        /// Feature Delete
        /// </summary>
        /// <param name="featureDeleteRequest"></param>
        /// <returns></returns>
        public async Task<FeatureDeleteResponse> DeleteFeature(FeatureDeleteRequest featureDeleteRequest)
        {
            if (featureDeleteRequest is null)
            {
                throw new ArgumentNullException(nameof(featureDeleteRequest));
            }

            return (await _featureRepository.DeleteFeature(featureDeleteRequest)).ValidateResponseContainer().Response;            
        }
              
        /// <summary>
        /// Feature Update
        /// </summary>
        /// <param name="featureUpdateRequest"></param>
        /// <returns></returns>
        public async Task<FeatureUpdateResponse> UpdateFeature(FeatureUpdateRequest featureUpdateRequest)
        {
            if (featureUpdateRequest is null)
            {
                throw new ArgumentNullException(nameof(featureUpdateRequest));
            }

            return (await _featureRepository.UpdateFeature(featureUpdateRequest)).ValidateResponseContainer().Response;            
        }

        #endregion       
    }
}