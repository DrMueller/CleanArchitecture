using Microsoft.Extensions.Options;
using Mmu.CleanArchitecture.Application.Areas.Settings.Models;

namespace Mmu.CleanArchitecture.Application.Areas.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _settings;

        public AppSettingsProvider(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public AppSettings Settings => _settings.Value;
    }
}