using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages;

partial class Home
{
    [Inject] IStaticRepository _StaticRepository { get; set; }

    int? _AllDDNSsCount { get; set; }
    int? _AllTodayChangesCount { get; set; }
    int? _AllUsersCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _AllDDNSsCount = await _StaticRepository.GetAllDDNSsCount();
        _AllTodayChangesCount = await _StaticRepository.GetAllTodayChangesCount();
        _AllUsersCount = await _StaticRepository.GetAllUsersCount();
    }
}
