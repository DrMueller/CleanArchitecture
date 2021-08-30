using Lamar;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.UnitOfWorks;

namespace Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Implementation
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContainer _container;
        private readonly IAppDbContextFactory _dbContextFactory;

        public UnitOfWorkFactory(
            IContainer container,
            IAppDbContextFactory dbContextFactory)
        {
            _container = container;
            _dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork Create()
        {
            var dbContext = _dbContextFactory.Create();
            var unitOfWork = _container.GetInstance<UnitOfWork>();
            unitOfWork.Initialize(dbContext);

            return unitOfWork;
        }
    }
}