using DNSLab.Web.DTOs.Repositories.Subscription;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class SubscriptionRepository(IHttpServiceProvider _HttpServiceProvider) : ISubscriptionRepository
    {
        const string APIController = "Subscription";
        public Task<IEnumerable<PlanSectionDTO>?> GetPlans()
        {
            return _HttpServiceProvider.Get<IEnumerable<PlanSectionDTO>?>($"{APIController}/GetPlans");
        }
    }
}
