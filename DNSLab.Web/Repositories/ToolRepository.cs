using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class ToolRepository(IHttpServiceProvider _HttpServiceProvider) : IToolRepository
    {
        const string APIController = "Tool";

        public async Task<bool> IsPortOpen(string host, int port)
        {
            return await _HttpServiceProvider.Get<bool>($"{APIController}/IsPortOpen?host={host}&port={port}");
        }

        public async Task<string?> Ping(string host)
        {
            return await _HttpServiceProvider.Get<string?>($"{APIController}/Ping?host={host}");
        }
    }
}
