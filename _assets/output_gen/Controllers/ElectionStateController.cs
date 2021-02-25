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
    public class ElectionStatesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public ElectionStatesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List ElectionStates 
        [Authorize]
        [HttpGet("electionstates")]
        public IActionResult ListElectionStates()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<ElectionState> electionstates = uow.ElectionStates.ListAll();
                List<ElectionStateModel> models = mapper.Map<List<ElectionStateModel>>(electionstates);
                //-------------------------------
                result.SetSuccess("ElectionStates listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get ElectionState by Id
        [Authorize]
        [HttpGet("electionstate/{electionstateId}")]
        public IActionResult GetElectionState(int electionstateId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                ElectionState electionstate = uow.ElectionStates.GetById(electionstateId);
                ElectionStateModel model = mapper.Map<ElectionStateModel>(electionstate);
                result.SetSuccess("ElectionState retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create ElectionState
        [Authorize]
        [HttpPost("electionstates")]
        public IActionResult CreateElectionState([FromBody] ElectionStateModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                ElectionState electionstate = mapper.Map<ElectionState>(model);
                uow.ElectionStates.Add(electionstate);
                uow.Commit();
                result.SetSuccess("ElectionState created successfully.", electionstate);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update ElectionState
        [Authorize]
        [HttpPut("electionstate/{electionstateId}")]
        public IActionResult UpdateElectionState(int electionstateId, [FromBody] ElectionStateModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.ElectionStates.Exists(electionstateId))
                {
                    ElectionState electionstate = mapper.Map<ElectionState>(model);
                    uow.ElectionStates.Update(electionstate);
                    uow.Commit();
                    result.SetSuccess("ElectionState updated successfully.", electionstate);
                }
                else
                {
                    result.SetFailure("ElectionState not found");
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
        //--------------------------------------------------------------------------  Delete ElectionState
        [Authorize]
        [HttpDelete("electionstate/{electionstateId}")]
        public IActionResult DeleteElectionState(int electionstateId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                ElectionState electionstate = uow.ElectionStates.GetById(electionstateId);
                uow.ElectionStates.Delete(electionstate);
                uow.Commit();
                result.SetSuccess("ElectionState deleted successfully.");
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