using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Cases
{
    public interface ILoadAllIndividualsUseCase
    {
        Task<IReadOnlyCollection<LoadedIndividualResultDto>> ExecuteAsync();
    }
}
