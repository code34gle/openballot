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
    public class CandidatesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public CandidatesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Candidates 
        [Authorize]
        [HttpGet("candidates")]
        public IActionResult ListCandidates()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Candidate> candidates = uow.Candidates.ListAll();
                List<CandidateModel> models = mapper.Map<List<CandidateModel>>(candidates);
                //-------------------------------
                result.SetSuccess("Candidates listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Candidate by Id
        [Authorize]
        [HttpGet("candidate/{candidateId}")]
        public IActionResult GetCandidate(int candidateId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Candidate candidate = uow.Candidates.GetById(candidateId);
                CandidateModel model = mapper.Map<CandidateModel>(candidate);
                result.SetSuccess("Candidate retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Candidate
        [Authorize]
        [HttpPost("candidates")]
        public IActionResult CreateCandidate([FromBody] CandidateModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Candidate candidate = mapper.Map<Candidate>(model);
                uow.Candidates.Add(candidate);
                uow.Commit();
                result.SetSuccess("Candidate created successfully.", candidate);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Candidate
        [Authorize]
        [HttpPut("candidate/{candidateId}")]
        public IActionResult UpdateCandidate(int candidateId, [FromBody] CandidateModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Candidates.Exists(candidateId))
                {
                    Candidate candidate = mapper.Map<Candidate>(model);
                    uow.Candidates.Update(candidate);
                    uow.Commit();
                    result.SetSuccess("Candidate updated successfully.", candidate);
                }
                else
                {
                    result.SetFailure("Candidate not found");
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
        //--------------------------------------------------------------------------  Delete Candidate
        [Authorize]
        [HttpDelete("candidate/{candidateId}")]
        public IActionResult DeleteCandidate(int candidateId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Candidate candidate = uow.Candidates.GetById(candidateId);
                uow.Candidates.Delete(candidate);
                uow.Commit();
                result.SetSuccess("Candidate deleted successfully.");
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