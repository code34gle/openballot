using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using OB.Data;
using OB.Data.Models;
using OB.Data.Entities;

namespace OB.Registration.Controllers
{
    [Route("api")]
    public class OfficesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public OfficesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Offices 
        [Authorize]
        [HttpGet("offices")]
        public IActionResult ListOffices()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Office> offices = uow.Offices.ListAll();
                List<OfficeModel> models = mapper.Map<List<OfficeModel>>(offices);
                //-------------------------------
                result.SetSuccess("Offices listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Office by Id
        [Authorize]
        [HttpGet("office/{officeId}")]
        public IActionResult GetOffice(int officeId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Office office = uow.Offices.GetById(officeId);
                OfficeModel model = mapper.Map<OfficeModel>(office);
                result.SetSuccess("Office retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Office
        [Authorize]
        [HttpPost("offices")]
        public IActionResult CreateOffice([FromBody] OfficeModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Office office = mapper.Map<Office>(model);
                uow.Offices.Add(office);
                uow.Commit();
                result.SetSuccess("Office created successfully.", office);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Office
        [Authorize]
        [HttpPut("office/{officeId}")]
        public IActionResult UpdateOffice(int officeId, [FromBody] OfficeModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Offices.Exists(officeId))
                {
                    Office office = mapper.Map<Office>(model);
                    uow.Offices.Update(office);
                    uow.Commit();
                    result.SetSuccess("Office updated successfully.", office);
                }
                else
                {
                    result.SetFailure("Office not found");
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
        //--------------------------------------------------------------------------  Delete Office
        [Authorize]
        [HttpDelete("office/{officeId}")]
        public IActionResult DeleteOffice(int officeId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Office office = uow.Offices.GetById(officeId);
                uow.Offices.Delete(office);
                uow.Commit();
                result.SetSuccess("Office deleted successfully.");
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