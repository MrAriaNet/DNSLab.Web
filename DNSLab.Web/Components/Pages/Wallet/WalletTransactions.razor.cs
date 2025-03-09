using DNSLab.Web.DTOs.Repositories.Shared;
using DNSLab.Web.DTOs.Repositories.Wallet;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Wallet;

partial class WalletTransactions
{
    [Inject] IWalletRepository _WalletRepository { get; set; }

    PagedResult<WalletTransactionDTO>? _AllTransactions;
    protected override async Task OnInitializedAsync()
    {
        _AllTransactions = await _WalletRepository.GetWalletTransactions();
    }

    bool _Loading = false;
    async Task PageChanged(int page)
    {
        _Loading = true;
        _AllTransactions = await _WalletRepository.GetWalletTransactions(page);
        _Loading = false;
    }
}
