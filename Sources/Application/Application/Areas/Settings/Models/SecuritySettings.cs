using JetBrains.Annotations;

namespace Mmu.CleanArchitecture.Application.Areas.Settings.Models
{
    [PublicAPI]
    public class SecuritySettings
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}