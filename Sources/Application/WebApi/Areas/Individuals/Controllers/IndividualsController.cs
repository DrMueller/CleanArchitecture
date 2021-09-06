using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Dto;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Interactors;

namespace Mmu.CleanArchitecture.WebApi.Areas.Individuals.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IAppendRoleInteractor _appendRoleUseCase;
        private readonly ICreateIndividualInteractor _createIndividualUseCase;
        private readonly ILoadAllIndividualsInteractor _loadAllIndividualsUseCase;
        private readonly ILoadFirstIndividualWithRolesInteractor _loadFirstIndividualWithRolesUseCase;

        public IndividualsController(
            ICreateIndividualInteractor createIndividualUseCase,
            ILoadAllIndividualsInteractor loadAllIndividualsUseCase,
            ILoadFirstIndividualWithRolesInteractor loadFirstIndividualWithRolesUseCase,
            IAppendRoleInteractor appendRoleUseCase)
        {
            _createIndividualUseCase = createIndividualUseCase;
            _loadAllIndividualsUseCase = loadAllIndividualsUseCase;
            _loadFirstIndividualWithRolesUseCase = loadFirstIndividualWithRolesUseCase;
            _appendRoleUseCase = appendRoleUseCase;
        }

        [HttpPost("{individualId:long}/roles")]
        public async Task<IActionResult> AppendRoleAsync([FromRoute] long individualId, [FromBody] AppendRoleRequestDto dto)
        {
            await _appendRoleUseCase.ExecuteAsync(individualId, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await _createIndividualUseCase.ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualResultDto>>> LoadAllAsync()
        {
            var allIndividuals = await _loadAllIndividualsUseCase.ExecuteAsync();

            return Ok(allIndividuals);
        }

        [HttpGet("first")]
        public async Task<ActionResult<IndividualWithRolesDto>> LoadFirstIndividualWithRolesASync()
        {
            var individualWithRoles = await _loadFirstIndividualWithRolesUseCase.ExecuteAsync();

            return Ok(individualWithRoles);
        }
    }
}