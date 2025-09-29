using ApexCharts;
using DNSLab.Web.DTOs.Repositories.Payment;
using DNSLab.Web.DTOs.Repositories.Shared;
using DNSLab.Web.DTOs.Repositories.Wallet;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Admin;

partial class Payments
{
    [Inject] IPaymentRepository _PaymentRepository { get; set; }

    PagedResult<PaymentDTO>? _AllPayments;
    protected override async Task OnInitializedAsync()
    {
        _AllPayments = await _PaymentRepository.GetAllPayments();
    }

    bool _Loading = false;
    async Task PageChanged(int page)
    {
        _Loading = true;
        _AllPayments = await _PaymentRepository.GetAllPayments(page);
        _Loading = false;
    }
}
