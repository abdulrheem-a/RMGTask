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
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IMediator mediator, IEmployeeService EmployeeService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _employeeService = EmployeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeeList();

            return Ok(employees);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IPagedList<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IPagedList<EmployeeModel>>> SearchEmployees(SearchPageRequest request)
        {
            var employeePagedList = await _employeeService.SearchEmployee(request.Args);

            return Ok(employeePagedList);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(GetEmployeeByIdRequest request)
        {
            var employee = await _employeeService.GetEmployeeById(request.Id);

            return Ok(employee);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesByName(GetEmployeesByNameRequest request)
        {
            var employees = await _employeeService.GetEmployeesByName(request.Name);

            return Ok(employees);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesByCategoryId(GetEmployeesByDepartmentIdRequest request)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentId(request.DepartmentId);

            return Ok(employees);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<EmployeeModel>> CreateEmployee(CreateEmployeeRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteEmployeeById(DeleteEmployeeByIdRequest request)
        {
            var commandResult = await _mediator.Send(request);

            return Ok(commandResult);
        }
    }
}
