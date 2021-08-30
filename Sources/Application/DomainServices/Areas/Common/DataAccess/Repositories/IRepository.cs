using System.Diagnostics.CodeAnalysis;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }
}