using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Enums;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class BundleRepository(IHttpServiceProvider _HttpServiceProvider) : IBudleRepository
    {
        const string APIController = "Bundle";

        public Task<bool> CheckSbscriptionFeature(FeatureEnum feature)
        {
            return _HttpServiceProvider.Get<bool>($"{APIController}/CheckSbscriptionFeature?feature={(int)feature}");
        }

        public Task<IEnumerable<BundleDTO>?> GetAllSubscribes()
        {
            return _HttpServiceProvider.Get<IEnumerable<BundleDTO>?>($"{APIController}/GetAllSubscribes");
        }

        public Task<IEnumerable<FeatureSectionDTO>?> GetFeatures()
        {
            return _HttpServiceProvider.Get<IEnumerable<FeatureSectionDTO>?>($"{APIController}/GetFeatures", false);
        }

        public Task<IEnumerable<BundleDTO>?> GetSubscribes()
        {
            return _HttpServiceProvider.Get<IEnumerable<BundleDTO>?>($"{APIController}/GetSubscribes");
        }

        public Task<bool> Activate(ActiveBundleDTO model)
        {
            return _HttpServiceProvider.Post<ActiveBundleDTO, bool>($"{APIController}/Activate", model);
        }

        public Task<IEnumerable<BundleDurationDTO>?> GetBundleDurations()
        {
            return _HttpServiceProvider.Get<IEnumerable<BundleDurationDTO>?>($"{APIController}/GetBundleDurations", false);
        }
    }
}
