using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.ViewModels
{
    public class AvaliacoesViewModel
    {
        public int Id;
        public int TransportadoraId { get; set; }
        public int ClassificacaoId { get; set; }
        public IEnumerable<TransportadorasViewModel> Transportadoras { get; set; }
        public List<ClassificacoesViewModel> Classificacoes { get; set; }
        public Transportadora Transportadora { get; set; }
        public Classificacao Classificacao { get; set; }

        public AvaliacoesViewModel() { }

        public AvaliacoesViewModel(Avaliacao av)
        {
            this.Id = av.Id;
            this.Transportadora = av.Transportadora;
            this.Classificacao = av.Classificacao;
        }
    }
}