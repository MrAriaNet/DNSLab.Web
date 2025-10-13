namespace DNSLab.Web.Interfaces.Providers
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync();
        Task SetTokenAsync(AuthUserDTO model);
        Task DeleteTokenAsync();
    }
}
