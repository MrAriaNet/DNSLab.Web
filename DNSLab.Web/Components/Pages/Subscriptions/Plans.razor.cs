using DNSLab.Web.DTOs.Repositories.Subscription;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Subscriptions;

partial class Plans
{
    [Inject] ISubscriptionRepository _SubscriptionRepository { get; set; }

    IEnumerable<PlanSectionDTO>? _PlanSections { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _PlanSections = await _SubscriptionRepository.GetPlans();
    }

    PlanDiscountDTO? _SelectedPlanDiscount { get; set; }

    PlanDTO _SelectedPlan
    {
        get
        {
            if (_SelectedPlanDiscount != null)
            {
                return _PlanSections!.SelectMany(x => x.Plans).First(x => x.Discounts.Any(d => d.Id == _SelectedPlanDiscount.Id));
            }

            return null;
        }
    }
}
