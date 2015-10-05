using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDados.Entity
{
    public class Avaliacao : Base
    {
        public int Id { get; set;}
        public int ClassificacaoId { get; set; }
        public int TransportadoraId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Classificacao Classificacao { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}