using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities.Common
{
    public abstract class EntityWithTime : Entity
    {
        protected EntityWithTime()
        {
            CreationTime = DateTime.UtcNow;
        }

        [Index]
        [Column("creation_time")]
        public DateTime CreationTime { get; protected set; }

        [Index]
        [Column("end_time")]
        public DateTime? EndTime { get; set; }
    }
}
