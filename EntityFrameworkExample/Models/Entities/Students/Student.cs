using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    [Table("student", Schema = "public")]
    public class Student : Person
    {
        public Student() : base()
        {
            Teachers = new HashSet<Teacher>();
        }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
            Teachers = new HashSet<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}