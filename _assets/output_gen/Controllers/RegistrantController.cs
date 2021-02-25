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
    public class RegistrantsController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public RegistrantsController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Registrants 
        [Authorize]
        [HttpGet("registrants")]
        public IActionResult ListRegistrants()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Registrant> registrants = uow.Registrants.ListAll();
                List<RegistrantModel> models = mapper.Map<List<RegistrantModel>>(registrants);
                //-------------------------------
                result.SetSuccess("Registrants listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Registrant by Id
        [Authorize]
        [HttpGet("registrant/{registrantId}")]
        public IActionResult GetRegistrant(int registrantId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Registrant registrant = uow.Registrants.GetById(registrantId);
                RegistrantModel model = mapper.Map<RegistrantModel>(registrant);
                result.SetSuccess("Registrant retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Registrant
        [Authorize]
        [HttpPost("registrants")]
        public IActionResult CreateRegistrant([FromBody] RegistrantModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Registrant registrant = mapper.Map<Registrant>(model);
                uow.Registrants.Add(registrant);
                uow.Commit();
                result.SetSuccess("Registrant created successfully.", registrant);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Registrant
        [Authorize]
        [HttpPut("registrant/{registrantId}")]
        public IActionResult UpdateRegistrant(int registrantId, [FromBody] RegistrantModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Registrants.Exists(registrantId))
                {
                    Registrant registrant = mapper.Map<Registrant>(model);
                    uow.Registrants.Update(registrant);
                    uow.Commit();
                    result.SetSuccess("Registrant updated successfully.", registrant);
                }
                else
                {
                    result.SetFailure("Registrant not found");
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
        //--------------------------------------------------------------------------  Delete Registrant
        [Authorize]
        [HttpDelete("registrant/{registrantId}")]
        public IActionResult DeleteRegistrant(int registrantId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Registrant registrant = uow.Registrants.GetById(registrantId);
                uow.Registrants.Delete(registrant);
                uow.Commit();
                result.SetSuccess("Registrant deleted successfully.");
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