using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using OB.Registration;
using OB.Registration.Models;
using OB.Registration.Entities;

namespace OB.Registration.Controllers
{
    [Route("api")]
    public class QuestionsController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public QuestionsController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Questions 
        [Authorize]
        [HttpGet("questions")]
        public IActionResult ListQuestions()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Question> questions = uow.Questions.ListAll();
                List<QuestionModel> models = mapper.Map<List<QuestionModel>>(questions);
                //-------------------------------
                result.SetSuccess("Questions listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Question by Id
        [Authorize]
        [HttpGet("question/{questionId}")]
        public IActionResult GetQuestion(int questionId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Question question = uow.Questions.GetById(questionId);
                QuestionModel model = mapper.Map<QuestionModel>(question);
                result.SetSuccess("Question retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Question
        [Authorize]
        [HttpPost("questions")]
        public IActionResult CreateQuestion([FromBody] QuestionModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Question question = mapper.Map<Question>(model);
                uow.Questions.Add(question);
                uow.Commit();
                result.SetSuccess("Question created successfully.", question);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Question
        [Authorize]
        [HttpPut("question/{questionId}")]
        public IActionResult UpdateQuestion(int questionId, [FromBody] QuestionModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Questions.Exists(questionId))
                {
                    Question question = mapper.Map<Question>(model);
                    uow.Questions.Update(question);
                    uow.Commit();
                    result.SetSuccess("Question updated successfully.", question);
                }
                else
                {
                    result.SetFailure("Question not found");
                }

            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Delete Question
        [Authorize]
        [HttpDelete("question/{questionId}")]
        public IActionResult DeleteQuestion(int questionId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Question question = uow.Questions.GetById(questionId);
                uow.Questions.Delete(question);
                uow.Commit();
                result.SetSuccess("Question deleted successfully.");
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        #endregion
        //--------------------------------------------------------------------------
    }
}