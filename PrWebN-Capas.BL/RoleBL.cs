using PrWebN_Capas.DAL;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.BL
{
    public class RoleBL
    {
        public static async Task<Role> GetById(int id)
        {
            return await RoleDAL.GetById(id);
        }
        public static async Task<int> Create(Role pRole)
        {
            return await RoleDAL.Create(pRole);
        }
        public static async Task<int> Update(Role pRole)
        {
            return await RoleDAL.Update(pRole);
        }
        public static async Task<int> Delete(Role pRole)
        {
            return await RoleDAL.Delete(pRole);
        }
        public static async Task<List<Role>> GetAll()
        {
            return await RoleDAL.GetAll();
        }
    }
}
