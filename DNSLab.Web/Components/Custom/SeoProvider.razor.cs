using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Custom;

partial class SeoProvider
{
    [Parameter] public string Title { get; set; } = string.Empty;
    [Parameter] public string Meta_Description { get; set; } = String.Empty;
}
