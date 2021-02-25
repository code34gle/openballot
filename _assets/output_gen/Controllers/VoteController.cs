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
    public class VotesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public VotesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Votes 
        [Authorize]
        [HttpGet("votes")]
        public IActionResult ListVotes()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Vote> votes = uow.Votes.ListAll();
                List<VoteModel> models = mapper.Map<List<VoteModel>>(votes);
                //-------------------------------
                result.SetSuccess("Votes listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Vote by Id
        [Authorize]
        [HttpGet("vote/{voteId}")]
        public IActionResult GetVote(int voteId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Vote vote = uow.Votes.GetById(voteId);
                VoteModel model = mapper.Map<VoteModel>(vote);
                result.SetSuccess("Vote retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Vote
        [Authorize]
        [HttpPost("votes")]
        public IActionResult CreateVote([FromBody] VoteModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Vote vote = mapper.Map<Vote>(model);
                uow.Votes.Add(vote);
                uow.Commit();
                result.SetSuccess("Vote created successfully.", vote);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Vote
        [Authorize]
        [HttpPut("vote/{voteId}")]
        public IActionResult UpdateVote(int voteId, [FromBody] VoteModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Votes.Exists(voteId))
                {
                    Vote vote = mapper.Map<Vote>(model);
                    uow.Votes.Update(vote);
                    uow.Commit();
                    result.SetSuccess("Vote updated successfully.", vote);
                }
                else
                {
                    result.SetFailure("Vote not found");
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
        //--------------------------------------------------------------------------  Delete Vote
        [Authorize]
        [HttpDelete("vote/{voteId}")]
        public IActionResult DeleteVote(int voteId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Vote vote = uow.Votes.GetById(voteId);
                uow.Votes.Delete(vote);
                uow.Commit();
                result.SetSuccess("Vote deleted successfully.");
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