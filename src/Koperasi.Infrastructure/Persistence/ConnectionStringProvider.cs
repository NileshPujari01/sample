using Microsoft.Extensions.Configuration;

namespace Koperasi.Infrastructure.Persistence
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public IConfiguration Configuration { get; }
        public ConnectionStringProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetConnectionString()
        {
            return Configuration.GetConnectionString("ConnectionString");
        }
    }
}
