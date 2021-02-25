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
    public class MachinesController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; set; }
        private IMapper mapper;
        //-----------------------------------------------------
        public MachinesController(IUow uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        //--------------------------------------------------------------------------
        #region BASE CRUD
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  List Machines 
        [Authorize]
        [HttpGet("machines")]
        public IActionResult ListMachines()
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                //-------------------------------
                List<Machine> machines = uow.Machines.ListAll();
                List<MachineModel> models = mapper.Map<List<MachineModel>>(machines);
                //-------------------------------
                result.SetSuccess("Machines listed successfully.", models);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Get Machine by Id
        [Authorize]
        [HttpGet("machine/{machineId}")]
        public IActionResult GetMachine(int machineId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Machine machine = uow.Machines.GetById(machineId);
                MachineModel model = mapper.Map<MachineModel>(machine);
                result.SetSuccess("Machine retrieved successfully.", model);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Create Machine
        [Authorize]
        [HttpPost("machines")]
        public IActionResult CreateMachine([FromBody] MachineModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            if (model == null)
                throw new Exception("Input request is null.");
            //-----------------------------------------------------
            try
            {
                Machine machine = mapper.Map<Machine>(model);
                uow.Machines.Add(machine);
                uow.Commit();
                result.SetSuccess("Machine created successfully.", machine);
            }
            catch (Exception ex)
            {
                result.SetFailure(ex.GetBaseException().Message);
            }
            //-----------------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------  Update Machine
        [Authorize]
        [HttpPut("machine/{machineId}")]
        public IActionResult UpdateMachine(int machineId, [FromBody] MachineModel model)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                if (uow.Machines.Exists(machineId))
                {
                    Machine machine = mapper.Map<Machine>(model);
                    uow.Machines.Update(machine);
                    uow.Commit();
                    result.SetSuccess("Machine updated successfully.", machine);
                }
                else
                {
                    result.SetFailure("Machine not found");
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
        //--------------------------------------------------------------------------  Delete Machine
        [Authorize]
        [HttpDelete("machine/{machineId}")]
        public IActionResult DeleteMachine(int machineId)
        {
            ApiResult result = new ApiResult();
            //-----------------------------------------------------
            try
            {
                Machine machine = uow.Machines.GetById(machineId);
                uow.Machines.Delete(machine);
                uow.Commit();
                result.SetSuccess("Machine deleted successfully.");
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