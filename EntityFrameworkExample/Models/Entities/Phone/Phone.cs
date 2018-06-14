using EntityFrameworkExample.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities
{
    [Table("phone", Schema = "public")]
    public class Phone : EntityWithTime
    {
        public Phone() { }

        public Phone(string number)
        {
            Number = number;
        }

        [Column("number")]
        public string Number { get; set; }

        [Column("person_id")]
        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}
