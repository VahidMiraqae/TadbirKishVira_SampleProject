using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application;
using SampleProject.Core;
using SampleProject.Infrastructure.Data;
using SampleProject.Web.DTOs;
using SampleProject.Web.DTOs.Common;
using SampleProject.Web.Validators;
using System.Net;

namespace SampleProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class InsuranceController : ControllerBase
    {
        private AppDbContext _db;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;

        public InsuranceController(AppDbContext db, IMapper mapper, IInsuranceService insuranceService)
        {
            _db = db;
            _mapper = mapper;
            _insuranceService = insuranceService;
        }

        [HttpGet("Coverage-Type")]
        public IActionResult Get()
        {
            if (!TryGetCoverageTypes(out var coverageTypes))
            {
                return Ok(new ErrorResponse());
            }
            var response = CommonResponse.OkResponse(coverageTypes.Values.Select(aa => _mapper.Map<CoverageTypeDto>(aa)));
            return Ok(response);
        }
         

        [HttpPost]
        public IActionResult Post([FromBody] RequestDto requestDto)
        {
            if (!TryGetCoverageTypes(out var coverageTypes))
            {
                return Ok(new ErrorResponse());
            } 

            var validator = new ReqeustDtoValidator(coverageTypes);
            var validationResult = validator.Validate(requestDto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(aa => new ValidationViolationDto(aa)).ToList();
                var response = CommonResponse.BackRequestResponse(errors);
                return Ok(response);
            }

            var request = _mapper.Map<Request>(requestDto);

            try
            {
                _insuranceService.ProcessRequest(request, coverageTypes);
            }
            catch (Exception)
            {
                return Ok(new ErrorResponse());
            }

            var requestProcessedDto = _mapper.Map<RequestProcessedDto>(requestDto);
            requestProcessedDto.Total = request.Total;


            return Ok(CommonResponse.OkResponse(requestProcessedDto));

        }


    }
}