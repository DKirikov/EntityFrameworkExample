using EntityFrameworkExample.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    public class TeacherManager : EntityManager<Teacher>
    {
        public TeacherManager(DbSet<Teacher> dbSet)
            : base(dbSet)
        {
        }

        public Teacher AddOrUpdate(string firstName, string lastName)
        {
            var person = dbSet.FirstOrDefault(p => p.LastName == lastName);
            if (person == null)
            {
                person = new Teacher(firstName, lastName);

                dbSet.Add(person);
            }
            else
            {
                person.FirstName = firstName;
            }

            return person;
        }
    }
}
