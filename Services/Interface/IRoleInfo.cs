using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Dtoa;
using tutorial1.Models;

namespace tutorial1.Services.Interface
{
    public interface IRoleInfo
    {
        Task<List<role_info>> GetQueryRoleList();
        Task<role_info> CreateRoleInfo(role_info_create role);
    }
}
