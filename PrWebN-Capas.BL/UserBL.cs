using PrWebN_Capas.DAL;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.BL
{
    public class UserBL
    {
        public static async Task<User> Login(User pUser)
        {
            return await UserDAL.Login(pUser);
        }

        public static async Task<User> GetById(int id)
        {
            return await UserDAL.GetById(id);
        }

        public static async Task<int> Create(User pUser)
        {
            return await UserDAL.Create(pUser);
        }
        public static async Task<int> Update(User pUser)
        {
            return await UserDAL.Update(pUser);
        }
        public static async Task<int> Delete(User pUser)
        {
            return await UserDAL.Delete(pUser);
        }
        public static async Task<List<User>> GetAll()
        {
            return await UserDAL.GetAll();
        }
    }
}
