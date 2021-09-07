using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Dto;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.DeleteIndividual.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Interactors;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Interactors;

namespace Mmu.CleanArchitecture.WebApi.Areas.Individuals.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IAppendRoleInteractor _appendRoleInteractor;
        private readonly IDeleteIndividualInteractor _deleteIndividualInteractor;
        private readonly IUpdateIndividualInteractor _updateIndividualInteractor;
        private readonly ICreateIndividualInteractor _createIndividualInteractor;
        private readonly ILoadAllIndividualsInteractor _loadAllIndividualsInteractor;
        private readonly ILoadFirstIndividualWithRolesInteractor _loadFirstIndividualWithRolesInteractor;

        public IndividualsController(
            ICreateIndividualInteractor createIndividualInteractor,
            ILoadAllIndividualsInteractor loadAllIndividualsInteractor,
            ILoadFirstIndividualWithRolesInteractor loadFirstIndividualWithRolesInteractor,
            IAppendRoleInteractor appendRoleInteractor,
            IDeleteIndividualInteractor deleteIndividualInteractor,
            IUpdateIndividualInteractor updateIndividualInteractor)
        {
            _createIndividualInteractor = createIndividualInteractor;
            _loadAllIndividualsInteractor = loadAllIndividualsInteractor;
            _loadFirstIndividualWithRolesInteractor = loadFirstIndividualWithRolesInteractor;
            _appendRoleInteractor = appendRoleInteractor;
            _deleteIndividualInteractor = deleteIndividualInteractor;
            _updateIndividualInteractor = updateIndividualInteractor;
        }

        [HttpPost("{individualId:long}/roles")]
        public async Task<IActionResult> AppendRoleAsync([FromRoute] long individualId, [FromBody] AppendRoleRequestDto dto)
        {
            await _appendRoleInteractor.ExecuteAsync(individualId, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await _createIndividualInteractor.ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualResultDto>>> LoadAllAsync()
        {
            var allIndividuals = await _loadAllIndividualsInteractor.ExecuteAsync();

            return Ok(allIndividuals);
        }

        [HttpPut("{individualId:long}")]
        public async Task<IActionResult> UpdateIndividualAsync([FromRoute] long individualId, [FromBody] IndividualToUpdateDto dto)
        {
            await _updateIndividualInteractor.ExecuteAsync(individualId, dto);

            return Ok();
        }

        [HttpDelete("{individualId:long}")]
        public async Task<IActionResult> DeleteIndividualAsync([FromRoute] long individualId)
        {
            await _deleteIndividualInteractor.ExecuteAsync(individualId);

            return Ok();
        }


        [HttpGet("first")]
        public async Task<ActionResult<IndividualWithRolesDto>> LoadFirstIndividualWithRolesASync()
        {
            var individualWithRoles = await _loadFirstIndividualWithRolesInteractor.ExecuteAsync();

            return Ok(individualWithRoles);
        }
    }
}