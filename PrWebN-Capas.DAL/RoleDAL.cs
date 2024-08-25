using Microsoft.EntityFrameworkCore;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.DAL
{
    public class RoleDAL
    {
        public static async Task<Role> GetById(int id)
        {
            var role = new Role();
            using (var dbContext = new ComunDB())
            {
                role = await dbContext.Roles.FirstOrDefaultAsync(s => s.Id == id);
            }

            return role;
        }

        public static async Task<int> Create(Role pRole)
        {
            int result = 0;
            using (var dbContext = new ComunDB())
            {
                dbContext.Add(pRole);
                result = await dbContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Update(Role pRole)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var role = await bdContext.Roles.FirstOrDefaultAsync(r => r.Id == pRole.Id);
                role.Name = pRole.Name;
                bdContext.Update(role);
                result = await bdContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Delete(Role pRole)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var role = await bdContext.Roles.FirstOrDefaultAsync(r => r.Id == pRole.Id);
                bdContext.Remove(role);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Role>> GetAll()
        {
            var role = new List<Role>();
            using (var bdContext = new ComunDB())
            {
                role = await bdContext.Roles.ToListAsync();
            }
            return role;
        }
    }
}
