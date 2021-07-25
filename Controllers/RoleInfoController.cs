using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Dtoa;
using tutorial1.Models;
using tutorial1.Services.Interface;

namespace tutorial1.Controllers
{
    public class RoleInfoController : Controller
    {
        private readonly IRoleInfo _roleInfoService;
        public RoleInfoController(IRoleInfo roleInfoService)
        {
            _roleInfoService = roleInfoService;
        }

        [HttpGet]
        [Route("getAllRole")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _roleInfoService.GetQueryRoleList());
        }

        [HttpPost]
        [Route("createRole")]
        public async Task<IActionResult> CreateUser([FromBody] role_info_create role)
        {
            return Ok(await _roleInfoService.CreateRoleInfo(role));
        }
    }
}
