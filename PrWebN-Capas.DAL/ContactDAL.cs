using Microsoft.EntityFrameworkCore;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.DAL
{
    public class ContactDAL
    {
        public static async Task<Contact> GetById(int id)
        {
            var contact = new Contact();
            using (var dbContext = new ComunDB())
            {
                contact = await dbContext.Contacts.FirstOrDefaultAsync(s => s.Id == id);
            }

            return contact;
        }

        public static async Task<int> Create(Contact pContact)
        {
            int result = 0;
            using (var dbContext = new ComunDB())
            {
                dbContext.Add(pContact);
                result = await dbContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Update(Contact pContact)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var contact = await bdContext.Contacts.FirstOrDefaultAsync(r => r.Id == pContact.Id);
                contact.Name = pContact.Name;
                contact.LastName = pContact.LastName;
                bdContext.Update(contact);
                result = await bdContext.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> Delete(Contact pContact)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                var contact = await bdContext.Contacts.FirstOrDefaultAsync(r => r.Id == pContact.Id);
                bdContext.Remove(contact);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Contact>> GetAll()
        {
            var contact = new List<Contact>();
            using (var bdContext = new ComunDB())
            {
                contact = await bdContext.Contacts.ToListAsync();
            }
            return contact;
        }
    }
}
