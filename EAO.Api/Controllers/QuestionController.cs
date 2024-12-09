using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }


        /// <summary>
        /// This endpoint is used to get list of Questions by format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns>list of Questions</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Question/GetQuestionsByFormat
        /// 
        /// </remarks>
        /// <response code="200"> Return list of Questions includes id and name </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>
        /// <response code="400">Returns Bad Request: Missing or invalid parameters</response>

        [HttpGet]
        [Route("GetQuestionByFormat")]
        [Produces("application/json")]
        public IActionResult GetQuestionsByFormat(string format)
        {
            var list = _questionService.GetQuestionList(format)
                .AsEnumerable();

            return Ok(list);
        }


        /// <summary>
        /// This endpoint is used to get a list of the question format used as a parameter when question filtering is needed.
        /// </summary>
        /// <returns>list of question format</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Question/GetQuestionsFormat
        /// 
        /// </remarks>
        /// <response code="200"> List returns the format of questions including id and name </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

        [HttpGet]
        [Route("GetQuestionFormatList")]
        [Produces("application/json")]
        public IActionResult GetQuestionsFormat()
        {
            var list = _questionService.GetQuestionList()
                .Select(e => e.Format).Distinct()
                .ToList();

            return Ok(list);
        }


    }
}
