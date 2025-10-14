using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IBudleRepository
    {
        Task<IEnumerable<FeatureSectionDTO>?> GetFeatures();
        Task<IEnumerable<BundleDurationDTO>?> GetBundleDurations();
        Task<bool> Activate(ActiveBundleDTO model);
        Task<IEnumerable<BundleDTO>?> GetSubscribes();
        Task<IEnumerable<BundleDTO>?> GetAllSubscribes();
        Task<bool> CheckSbscriptionFeature(FeatureEnum feature);
    }
}
