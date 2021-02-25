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
    public class UserAccountsController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public UserAccountsController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List UserAccounts 
        [Authorize]
        [HttpGet("useraccounts")]
        public IActionResult ListUserAccounts()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<UserAccount> useraccounts = uow.UserAccounts.ListAll();
                List<UserAccountModel> models = mapper.Map<List<UserAccountModel>>(useraccounts);
                //-------------------------------
                result.SetSuccess("UserAccounts listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get UserAccount by Id
        [Authorize]
        [HttpGet("useraccount/{useraccountId}")]
        public IActionResult GetUserAccount(int useraccountId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                UserAccount useraccount = uow.UserAccounts.GetById(useraccountId);
                UserAccountModel model = mapper.Map<UserAccountModel>(useraccount);
                result.SetSuccess("UserAccount retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create UserAccount
        [Authorize]
        [HttpPost("useraccounts")]
        public IActionResult CreateUserAccount([FromBody] UserAccountModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                UserAccount useraccount = mapper.Map<UserAccount>(model);
                uow.UserAccounts.Add(useraccount);
                uow.Commit();
                result.SetSuccess("UserAccount created successfully.", useraccount);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update UserAccount
        [Authorize]
        [HttpPut("useraccount/{useraccountId}")]
        public IActionResult UpdateUserAccount(int useraccountId, [FromBody] UserAccountModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.UserAccounts.Exists(useraccountId))
                {
                    UserAccount useraccount = mapper.Map<UserAccount>(model);
                    uow.UserAccounts.Update(useraccount);
                    uow.Commit();
                    result.SetSuccess("UserAccount updated successfully.", useraccount);
                }
                else
                {
                    result.SetFailure("UserAccount not found");
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
        //--------------------------------------------------------------------------  Delete UserAccount
        [Authorize]
        [HttpDelete("useraccount/{useraccountId}")]
        public IActionResult DeleteUserAccount(int useraccountId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                UserAccount useraccount = uow.UserAccounts.GetById(useraccountId);
                uow.UserAccounts.Delete(useraccount);
                uow.Commit();
                result.SetSuccess("UserAccount deleted successfully.");
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