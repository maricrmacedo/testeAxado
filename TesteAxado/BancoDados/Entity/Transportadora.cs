using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDados.Entity
{
    public class Transportadora : Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}