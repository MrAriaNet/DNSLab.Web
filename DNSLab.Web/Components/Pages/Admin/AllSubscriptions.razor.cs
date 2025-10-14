using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Admin;

partial class AllSubscriptions
{
    [Inject] IBudleRepository _SubscriptionsRepository { get; set; }

    IEnumerable<UserBundleDTO>? _UserBundles;
    bool _Loading = false;
    protected override async Task OnInitializedAsync()
    {
        _Loading = true;
        _UserBundles = await _SubscriptionsRepository.GetAllBundles();
        _Loading = false;
    }
}
