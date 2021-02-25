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
    public class UserAccountRolesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public UserAccountRolesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List UserAccountRoles 
        [Authorize]
        [HttpGet("useraccountroles")]
        public IActionResult ListUserAccountRoles()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<UserAccountRole> useraccountroles = uow.UserAccountRoles.ListAll();
                List<UserAccountRoleModel> models = mapper.Map<List<UserAccountRoleModel>>(useraccountroles);
                //-------------------------------
                result.SetSuccess("UserAccountRoles listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get UserAccountRole by Id
        [Authorize]
        [HttpGet("useraccountrole/{useraccountroleId}")]
        public IActionResult GetUserAccountRole(int useraccountroleId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                UserAccountRole useraccountrole = uow.UserAccountRoles.GetById(useraccountroleId);
                UserAccountRoleModel model = mapper.Map<UserAccountRoleModel>(useraccountrole);
                result.SetSuccess("UserAccountRole retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create UserAccountRole
        [Authorize]
        [HttpPost("useraccountroles")]
        public IActionResult CreateUserAccountRole([FromBody] UserAccountRoleModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                UserAccountRole useraccountrole = mapper.Map<UserAccountRole>(model);
                uow.UserAccountRoles.Add(useraccountrole);
                uow.Commit();
                result.SetSuccess("UserAccountRole created successfully.", useraccountrole);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update UserAccountRole
        [Authorize]
        [HttpPut("useraccountrole/{useraccountroleId}")]
        public IActionResult UpdateUserAccountRole(int useraccountroleId, [FromBody] UserAccountRoleModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.UserAccountRoles.Exists(useraccountroleId))
                {
                    UserAccountRole useraccountrole = mapper.Map<UserAccountRole>(model);
                    uow.UserAccountRoles.Update(useraccountrole);
                    uow.Commit();
                    result.SetSuccess("UserAccountRole updated successfully.", useraccountrole);
                }
                else
                {
                    result.SetFailure("UserAccountRole not found");
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
        //--------------------------------------------------------------------------  Delete UserAccountRole
        [Authorize]
        [HttpDelete("useraccountrole/{useraccountroleId}")]
        public IActionResult DeleteUserAccountRole(int useraccountroleId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                UserAccountRole useraccountrole = uow.UserAccountRoles.GetById(useraccountroleId);
                uow.UserAccountRoles.Delete(useraccountrole);
                uow.Commit();
                result.SetSuccess("UserAccountRole deleted successfully.");
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