using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercicios
{
    public class DataBaseInitializer : IDatabaseInitializer<Context>
    {
        public void InitializeDatabase(Context context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}