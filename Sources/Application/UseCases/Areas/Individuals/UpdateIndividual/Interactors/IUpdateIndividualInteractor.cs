using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Interactors
{
    public interface IUpdateIndividualInteractor
    {
        Task ExecuteAsync(long individualId, IndividualToUpdateDto dto);
    }
}
