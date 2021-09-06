using JetBrains.Annotations;

namespace Mmu.CleanArchitecture.CrossCutting.Areas.Settings.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string ConnectionString { get; set; }

        public SecuritySettings SecuritySettings { get; set; }
    }
}