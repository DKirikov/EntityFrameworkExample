using EntityFrameworkExample.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    [Table("person", Schema = "public")]
    public class Person : EntityWithTime
    {
        public Person() 
        {
            Phones = new HashSet<Phone>();
        }

        public Person(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phones { get; set; }
    }
}