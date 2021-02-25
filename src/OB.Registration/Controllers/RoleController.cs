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
    public class RolesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public RolesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Roles 
        [Authorize]
        [HttpGet("roles")]
        public IActionResult ListRoles()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Role> roles = uow.Roles.ListAll();
                List<RoleModel> models = mapper.Map<List<RoleModel>>(roles);
                //-------------------------------
                result.SetSuccess("Roles listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Role by Id
        [Authorize]
        [HttpGet("role/{roleId}")]
        public IActionResult GetRole(int roleId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Role role = uow.Roles.GetById(roleId);
                RoleModel model = mapper.Map<RoleModel>(role);
                result.SetSuccess("Role retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Role
        [Authorize]
        [HttpPost("roles")]
        public IActionResult CreateRole([FromBody] RoleModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Role role = mapper.Map<Role>(model);
                uow.Roles.Add(role);
                uow.Commit();
                result.SetSuccess("Role created successfully.", role);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Role
        [Authorize]
        [HttpPut("role/{roleId}")]
        public IActionResult UpdateRole(int roleId, [FromBody] RoleModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Roles.Exists(roleId))
                {
                    Role role = mapper.Map<Role>(model);
                    uow.Roles.Update(role);
                    uow.Commit();
                    result.SetSuccess("Role updated successfully.", role);
                }
                else
                {
                    result.SetFailure("Role not found");
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
        //--------------------------------------------------------------------------  Delete Role
        [Authorize]
        [HttpDelete("role/{roleId}")]
        public IActionResult DeleteRole(int roleId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Role role = uow.Roles.GetById(roleId);
                uow.Roles.Delete(role);
                uow.Commit();
                result.SetSuccess("Role deleted successfully.");
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