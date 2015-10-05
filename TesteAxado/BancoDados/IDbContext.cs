using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercicios
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : Base;
        int SaveChanges();
    }
}