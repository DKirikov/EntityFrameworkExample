using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    [Table("teacher", Schema = "public")]
    public class Teacher : Person
    {
        public Teacher() : base()
        {
            Students = new HashSet<Student>();
        }

        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            Students = new HashSet<Student>();
        }

        public virtual ICollection<Student> Students { get; set; }
    }
}
