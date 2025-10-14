using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IBudleRepository
    {
        Task<IEnumerable<FeatureSectionDTO>?> GetFeatures();
        Task<IEnumerable<BundleDurationDTO>?> GetBundleDurations();
        Task<bool> Activate(ActiveBundleDTO model);
        Task<IEnumerable<UserBundleDTO>?> GetBundles();
        Task<IEnumerable<UserBundleDTO>?> GetAllBundles();
        Task<bool> CheckSbscriptionFeature(FeatureEnum feature);
    }
}
