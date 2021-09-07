using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.DeleteIndividual.Interactors
{
    public interface IDeleteIndividualInteractor
    {
        Task ExecuteAsync(long individualId);
    }
}
