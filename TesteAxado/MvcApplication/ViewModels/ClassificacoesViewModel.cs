using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.ViewModels
{
    public class ClassificacoesViewModel: Classificacao
    {
        public ClassificacoesViewModel(Classificacao c)
        {
            this.Id = c.Id;
            this.Descricao = c.Descricao;
        }
    }
}