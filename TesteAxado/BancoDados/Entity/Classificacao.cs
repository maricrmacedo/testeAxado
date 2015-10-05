using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDados.Entity
{
    public class Classificacao : Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}