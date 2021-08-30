using Mmu.CleanArchitecture.Application.Areas.Settings.Models;

namespace Mmu.CleanArchitecture.Application.Areas.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}