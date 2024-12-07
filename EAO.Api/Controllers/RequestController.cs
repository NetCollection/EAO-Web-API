using EAO.Api.Extensions;
using EAO.BL.DTOs.Request;
using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RequestController : ExtraController
    {
        private readonly RequestService _requestService;
        private readonly PatientService _patientService;
        private readonly IncidentService _incidentService;
        private readonly GovernorateService _governorateService;
        private readonly AreaService _areaService;
        public RequestController(TicketService ticketService, RequestService requestService, PatientService patientService, IncidentService incidentService, GovernorateService governorateService, AreaService areaService)
        {
            _requestService = requestService;
            _patientService = patientService;
            _incidentService = incidentService;
            _governorateService = governorateService;
            _areaService = areaService;
        }




        [HttpPost]
        [Route("AddRequest")]
        [Produces("application/json")]
        public IActionResult AddRequest(AddRequestDto addRequestDto)
        {

            Claim createdObj = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault();

            if (createdObj != null)
            {
                addRequestDto.CreatedBy = createdObj.Value;
            }

            if (addRequestDto == null) return BadRequest("Request data is required.");

            //Validation State
            #region Validation
            //CallerName
            if (string.IsNullOrEmpty(addRequestDto.CallerName))
            {
                ModelState.AddModelError("CallerName", "Caller Name is not valid");
            }

            //CallerPhone
            if (string.IsNullOrEmpty(addRequestDto.CallerPhone))
            {
                ModelState.AddModelError("CallerPhone", "Caller Phone is not valid");
            }

            //FullName
            if (string.IsNullOrEmpty(addRequestDto.FullName))
            {
                ModelState.AddModelError("FullName", "Full Name is not valid");
            }

            //FirstName
            if (string.IsNullOrEmpty(addRequestDto.FirstName))
            {
                ModelState.AddModelError("FirstName", "First Name is not valid");
            }

            //Validation State
            if (!_patientService.IsGenderValid(addRequestDto.GenderId))
            {
                ModelState.AddModelError("genderId", "gender id is not valid");
            }

            //Nationality 
            if (!_patientService.IsNationalityValid(addRequestDto.NationalityId))
            {
                ModelState.AddModelError("nationalityId", "nationality id is not valid");
            }

            //SubType
            if (!_incidentService.IsSubTypeValid(addRequestDto.SubType))
            {
                ModelState.AddModelError("subType", "sub type id is not valid");
            }

            //Governorate
            if (!_governorateService.IsGovernorateValid(addRequestDto.GovernorateId))
            {
                ModelState.AddModelError("governorateId", "governorate id is not valid");
            }

            //Area 
            if (!_areaService.IsAreaValid(addRequestDto.AreaId, addRequestDto.GovernorateId))
            {
                ModelState.AddModelError("areaId", "area Id is not valid");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            var response = _requestService.Add(addRequestDto);


            return Ok(new { requestId = response.ValueId });

        }






    }
}
