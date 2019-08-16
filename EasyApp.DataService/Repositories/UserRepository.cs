using EasyApp.DataAccess;
using EasyApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.DataService.Repositories
{
    public class UserRepository : GenericRepository<User, EasyAppDBContext> , IUserRepository
    {
        public UserRepository(EasyAppDBContext context) : base(context)
        {
        }

        public async Task<User> CheckCredentials(string username,string password)
        {
            return await Context.Users.SingleOrDefaultAsync(u => u.Username.Equals(username) && u.password.Equals(password));
        }
    }
}
