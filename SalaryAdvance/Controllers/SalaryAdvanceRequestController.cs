using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaryAdvance.Application.Commands;
using SalaryAdvance.Application.Queries;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;
using static SalaryAdvance.Application.Queries.GetSalaryAdvanceRequestsByEmployeeQuery;
using static SalaryAdvance.Application.Queries.GetSalaryAdvanceRequestsQuery;

namespace SalaryAdvance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryAdvanceRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalaryAdvanceRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetSalaryAdvanceRequest(Guid requestId)
        {
            var query = new GetRequestsQuery(requestId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{employeeId}/employee")]
        public async Task<IActionResult> GetSalaryAdvanceRequestsByEmployee(int employeeId)
        {
            var query = new GetSalaryAdvanceRequestByEmployeeQuery(employeeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertSalaryAdvanceRequest(SalaryAdvanceRequest employee)
        {

            var response = await _mediator.Send(new RequestSalaryAdvanceCommand(employee));


            return Ok(response);
        }
        //private bool SalaryAdvanceRequestExists(Guid? id)
        //{
        //    return _context.SalaryAdvanceRequests.Any(e => e.RequestId == id);
        //}
    }
}
