namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}