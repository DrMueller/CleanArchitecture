namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}