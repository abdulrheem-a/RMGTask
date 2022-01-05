using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using RMGTask.Application.Models;
using RMGTask.Core.Paging;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RMGTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IMediator mediator, IDepartmentService DepartmentService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _departmentService = DepartmentService ?? throw new ArgumentNullException(nameof(DepartmentService));
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentList();

            return Ok(departments);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(DepartmentModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentById(GetDepartmentByIdRequest request)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);

            return Ok(department);
        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(DepartmentModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<DepartmentModel>> CreateDepartment(CreateDepartmentRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteDepartmentById(DeleteDepartmentByIdRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }
    }
}
