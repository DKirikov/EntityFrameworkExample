using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models.Entities.Common
{
    public abstract class EntityManager<TEntity>
        where TEntity : Entity
    {
        protected EntityManager(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        protected readonly DbSet<TEntity> dbSet;
    }
}
