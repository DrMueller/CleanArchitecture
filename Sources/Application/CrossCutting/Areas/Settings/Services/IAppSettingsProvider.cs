using Mmu.CleanArchitecture.CrossCutting.Areas.Settings.Models;

namespace Mmu.CleanArchitecture.CrossCutting.Areas.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}