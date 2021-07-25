using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Models;
using tutorial1.Services.Dependency;
using tutorial1.Services.Interface;

namespace tutorial1.Helpers
{
    public static class AddServices
    {
        public static void Injection(IServiceCollection services)
        {
            services.AddScoped<IUserInfo, DUserInfo>();
            services.AddScoped<IRoleInfo, DRoleInfo>();
        }
    }
}
