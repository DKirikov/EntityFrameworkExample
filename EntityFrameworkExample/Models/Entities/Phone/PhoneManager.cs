using EntityFrameworkExample.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    public class PhoneManager : EntityManager<Phone>
    {
        public PhoneManager(DbSet<Phone> dbSet)
            : base(dbSet)
        {
        }

        public Phone AddIfNeed(Person person, string phoneNumber)
        {
            var phone = person.Phones.FirstOrDefault(ph => ph.Number == phoneNumber);
            if (phone == null)
            {
                phone = new Phone(phoneNumber);
                phone.PersonID = person.ID;
                dbSet.Add(phone);
            }

            return phone;
        }
    }
}
