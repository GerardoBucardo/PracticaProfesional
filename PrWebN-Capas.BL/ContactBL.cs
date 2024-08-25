using PrWebN_Capas.DAL;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.BL
{
    public class ContactBL
    {
        public static async Task<Contact> GetById(int id)
        {
            return await ContactDAL.GetById(id);
        }
        public static async Task<int> Create(Contact pContact)
        {
            return await ContactDAL.Create(pContact);
        }
        public static async Task<int> Update(Contact pContact)
        {
            return await ContactDAL.Update(pContact);
        }
        public static async Task<int> Delete(Contact pContact)
        {
            return await ContactDAL.Delete(pContact);
        }
        public static async Task<List<Contact>> GetAll()
        {
            return await ContactDAL.GetAll();
        }
    }
}
