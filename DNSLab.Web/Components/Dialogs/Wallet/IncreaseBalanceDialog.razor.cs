using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Dialogs.Wallet;

partial class IncreaseBalanceDialog
{
    [Inject] IPaymentRepository _PaymentRepository { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    [CascadingParameter] IMudDialogInstance _MudDialog { get; set; }

    long _Amount;
    string _DisplayAmount = String.Empty;
    string _ErrorMessage = String.Empty;
    private void OnAmountTextChanged(string newValue)
    {
        var raw = newValue.Replace(",", "");
        if (long.TryParse(raw, out var parsed))
        {
            if (parsed == 0)
            {
                parsed = 500_000; //Rials
            }
            _Amount = parsed;
            _DisplayAmount = parsed.ToString("N0");
            _ErrorMessage = String.Empty;
        }
        else
        {
            _ErrorMessage = "مقدار وارد شده صحیح نیست";
        }
    }
    async Task Pay()
    {
        if (_Amount < 50_000 || _Amount > 500_000_000)
        {
            _ErrorMessage = "مقدار وارد شده باید بین 50،000 تا 500،000،000 ریال باشد";
            return;
        }

        string? paymentUrl = await _PaymentRepository.RequestPaymentUrl(_Amount);

        if (!String.IsNullOrEmpty(paymentUrl))
        {
            _NavigationManager.NavigateTo(paymentUrl, true);
        }
    }
}
