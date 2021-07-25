using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Models;
using tutorial1.Services.Interface;

namespace tutorial1.Services.Dependency
{
    public class DUserInfo: IUserInfo
    {
        private readonly db_tutorialContext _context;

        public DUserInfo(db_tutorialContext context)
        {
            _context = context;
        }

        ~DUserInfo()
        {
            GC.Collect();
        }

        public async Task<List<user_info>> GetQueryUserList()
        {
            return await _context.user_infos.ToListAsync();
        }

        public async Task<user_info> CreateUserInfo(user_info user)
        {
            _context.user_infos.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
