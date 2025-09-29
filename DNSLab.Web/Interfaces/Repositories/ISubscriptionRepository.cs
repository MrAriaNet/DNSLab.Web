using DNSLab.Web.DTOs.Repositories.Subscription;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<PlanSectionDTO>?> GetPlans();
    }
}
