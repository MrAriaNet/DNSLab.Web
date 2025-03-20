using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Custom;

partial class SeoProvider
{
    [Parameter] public string Title { get; set; }
    [Parameter] public string Meta_Description { get; set; }
}
