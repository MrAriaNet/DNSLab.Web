using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Admin;

partial class AllSubscriptions
{
    [Inject] IBudleRepository _SubscriptionsRepository { get; set; }

    IEnumerable<BundleDTO>? _Subscriptions;
    bool _Loading = false;
    protected override async Task OnInitializedAsync()
    {
        _Loading = true;
        _Subscriptions = await _SubscriptionsRepository.GetAllSubscribes();
        _Loading = false;
    }
}
