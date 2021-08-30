using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}