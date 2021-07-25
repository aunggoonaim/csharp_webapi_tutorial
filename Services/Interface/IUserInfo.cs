using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Models;

namespace tutorial1.Services.Interface
{
    public interface IUserInfo
    {
        Task<List<user_info>> GetQueryUserList();
        Task<user_info> CreateUserInfo(user_info user);
    }
}
