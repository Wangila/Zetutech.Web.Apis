using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetutech.Web.Api.ApplicationCore.Entities;
using Zetutech.Web.Api.ApplicationCore.Interfaces;
using Zetutech.Web.Api.Infrastructure.Data;
using Zetutech.Web.Api.Interfaces;

namespace Zetutech.Web.Api.Controllers.Api
{
   
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _questionService;
        private readonly ZetutechDataDbContext _context;
        private readonly IAppLogger<QuestionController> _logger;
        public QuestionController(
            IQuestionService questionService, 
            ZetutechDataDbContext context,
            IAppLogger<QuestionController> logger)
        {
            _questionService = questionService;
            _context = context;
            _logger = logger;
        }

        //[HttpGet]
        //[ProducesResponseType(200)]
        //public ActionResult<IEnumerable<Question>> GetAll()
        //{
        //    var questions = _questionService.GetAll().ToList();
        //    //return Ok(questions);
        //    return questions;
        //}

        /*
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await _questionService.GetAllAsync();         
            return Ok(questions);
        }
        */
        /*
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await _questionService.GetAllAsync(1,1,null);
            _logger.LogWarning("Question with ID {QuestionId} fetched.", 2);
            return Ok(questions);
        }
        */
       
       
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await _questionService.GetAllAsync();


            //Eager Loading
            /*
            var questions = await _context.Questions
                .Include(question => question.QuestionOptions)
                .ToAsyncEnumerable().ToList();
            */
            //Explicit Loading
            /*
            var questions = _context.Questions
                .Single(question => question.Id == 1);

            _context.Entry(questions)
                .Collection(q => q.QuestionOptions)
                .Load();
        */

            return Ok(questions);
        }

        [HttpGet("{pageIndex:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Question>>> GetByPage(int pageIndex)
        {
            var questions = await _questionService.GetAllAsync(pageIndex, 1, null);
            _logger.LogWarning("Question with ID {QuestionId} fetched.", 2);
            return Ok(questions);
        }

    }
}