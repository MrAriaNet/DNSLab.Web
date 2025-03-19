using DNSLab.Web.DTOs.Repositories.Subscription;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<PlanSectionDTO>?> GetPlans();
        Task<bool> Subscribe(int planId, int discountId);
    }
}
