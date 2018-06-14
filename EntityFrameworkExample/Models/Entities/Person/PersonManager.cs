using EntityFrameworkExample.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    public class PersonManager : EntityManager<Person>
    {
        public PersonManager(DbSet<Person> dbSet)
            : base(dbSet)
        { 
        }

        public Person AddOrUpdate(string firstName, string lastName)
        {
            var person = dbSet.FirstOrDefault(p => p.LastName == lastName);
            if (person == null)
            {
                person = new Person(firstName, lastName);

                dbSet.Add(person);
            }
            else
            {
                person.FirstName = firstName;
            }

            return person;
        }

        public List<PersonInfo> GetAllData()
        {
            var res = dbSet.Select(p => new PersonInfo()
                {
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    phoneNumbers = p.Phones.Select(ph => ph.Number).ToList()
                }).OrderBy(pi => pi.lastName).ToList();

            return res;
        }
    }
}
