using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Cases;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.WebApi.Areas.Individuals.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly ICreateIndividualUseCase _createIndividualUseCase;

        public IndividualsController(ICreateIndividualUseCase createIndividualUseCase)
        {
            _createIndividualUseCase = createIndividualUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await _createIndividualUseCase.ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<CreateIndividualRequestDto>>> LoadAllAsync()
        {
            return null;
        }
    }
}