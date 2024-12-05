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


        [HttpGet]
        [Route("GetQuestion")]
        [Produces("application/json")]
        public IActionResult GetQuestion()
        {
            var list = _questionService.GetQuestionList().ToList();

            return Ok(list);
        }

        [HttpGet]
        [Route("GetQuestionFormatList")]
        [Produces("application/json")]
        public IActionResult GetQuestionFormatList()
        {
            var list = _questionService.GetQuestionList()
                .Select(e => e.Format).Distinct()
                .ToList();

            return Ok(list);
        }


        [HttpGet]
        [Route("GetQuestionByFormat")]
        [Produces("application/json")]
        public IActionResult GetQuestionByFormat(string format)
        {
            var list = _questionService.GetQuestionList()
                .Where(e => e.Format == format)
                .ToList();

            return Ok(list);
        }
    }
}
