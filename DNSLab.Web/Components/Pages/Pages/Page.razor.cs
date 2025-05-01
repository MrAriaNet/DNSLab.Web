using DNSLab.Web.DTOs.Repositories.Page;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;
using System;

namespace DNSLab.Web.Components.Pages.Pages;

partial class Page
{
    [Inject] IPageRepository _PageRepository { get; set; }

    [Parameter] public Guid PageId { get; set; } = Guid.Empty;

    PageDTO _Page = new();

    IEnumerable<PageTypeDTO>? _Types { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        _Types = await _PageRepository.GetPageTypes();

        if (PageId != Guid.Empty)
        {
            var existPage = await _PageRepository.GetPage(PageId);
            if (existPage != null)
            {
                _Page = existPage;
            }
        }
    }

    public async Task Submit()
    {
        if (PageId == Guid.Empty)
        {
            await _PageRepository.CreatePage(_Page);
        }
        else
        {
            await _PageRepository.UpdatePage(_Page);
        }
    }
}
