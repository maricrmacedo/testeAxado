using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.ViewModels
{
    public class TransportadorasViewModel : Transportadora
    {
        public TransportadorasViewModel(Transportadora t)
        {
            this.Id = t.Id;
            this.Descricao = t.Descricao;
        }
    }
}