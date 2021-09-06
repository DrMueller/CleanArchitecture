using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.CrossCutting.Areas.Settings.Services;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts.Implementation;

namespace Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public AppDbContextFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public IAppDbContext Create()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(_appSettingsProvider.Settings.ConnectionString)
                .Options;

            return new AppDbContext(options);
        }
    }
}