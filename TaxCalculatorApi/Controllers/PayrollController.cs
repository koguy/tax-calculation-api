﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculatorApi.Application.Services.Interfaces;
using TaxCalculatorApi.Dtos;

namespace TaxCalculatorApi.Controllers
{
    [Route("api/payrolls")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpPost("calculate")]
        public ActionResult<PayrollDto> CalculatePayroll([FromBody]int grossAnnualSalary)
        {
            return Ok(_payrollService.GetPayrollInfo(grossAnnualSalary));
        }
    }
}
