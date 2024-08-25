using Microsoft.EntityFrameworkCore;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.DAL
{
    public class UserDAL
    {
        public static async Task<User> Login(User pUser)
        {
            var user = new User();
            using (var dbContext = new ComunDB())
            {
                user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == pUser.UserName &&
                u.UserPassword == pUser.UserPassword);
            }
            return user;

        }
        public static async Task<User> GetById(int id)
        {
            var user = new User();
            using (var dbContext = new ComunDB())
            {
                user = await dbContext.Users.Include(r => r.Roles).FirstOrDefaultAsync(s => s.Id == id);
            }

            return user;
        }
        public static async Task<int> Create(User pUser)
        {
            int result = 0;
            using (var dbContext = new ComunDB())
            {
                dbContext.Add(pUser);
                result = await dbContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Update(User pUser)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var user = await bdContext.Users.FirstOrDefaultAsync(r => r.Id == pUser.Id);
                user.UserName = pUser.UserName;
                user.UserPassword = pUser.UserPassword;
                user.RoleId = pUser.RoleId;
                bdContext.Update(user);
                result = await bdContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Delete(User pUser)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var user = await bdContext.Users.FirstOrDefaultAsync(r => r.Id == pUser.Id);
                bdContext.Remove(user);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<User>> GetAll()
        {
            var user = new List<User>();
            using (var bdContext = new ComunDB())
            {
                user = await bdContext.Users.ToListAsync();
            }
            return user;
        }
    }
}
