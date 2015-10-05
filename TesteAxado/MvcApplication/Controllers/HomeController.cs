using BancoDados.Entity;
using Exercicios;
using MvcApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private Context context;
        private Repository<Transportadora> repositorioTransportadora;
        private Repository<Classificacao> repositorioClassificacao;
        private Repository<Avaliacao> repositorioAvaliacao;

        public HomeController()
        {
            context = new Context();
            var dataBaseInitializer = new DataBaseInitializer();
            dataBaseInitializer.InitializeDatabase(context);
            repositorioTransportadora = new Repository<Transportadora>(context);
            repositorioClassificacao = new Repository<Classificacao>(context);
            repositorioAvaliacao = new Repository<Avaliacao>(context);
        }

        public ActionResult Index()
        {
            if (User.Identity.Name == "")
                return View("../Account/Login");

            int codigoUsuario = int.Parse(WebSecurity.GetUserId(User.Identity.Name).ToString());
            var avaliacoesUsuario = repositorioAvaliacao.FindBy(a => a.UsuarioId == codigoUsuario);
            List<AvaliacoesViewModel> lista = new List<AvaliacoesViewModel>();
            if (avaliacoesUsuario != null)
            {
                avaliacoesUsuario.ToList().ForEach(a=>
                {
                    lista.Add(new AvaliacoesViewModel(a));
                });
            }
            return View(lista);
        }

        public ActionResult Create()
        {
            AvaliacoesViewModel viewModel = new AvaliacoesViewModel();
            var listT = CarregarTransportadorasDisponíveis(WebSecurity.GetUserId(User.Identity.Name));
            var transportadoras = new List<TransportadorasViewModel>();
            listT.ForEach(a=>{
                transportadoras.Add(new TransportadorasViewModel(a));
            });
            viewModel.Transportadoras = transportadoras;
            var listC = repositorioClassificacao.GetAll();
            var classificacoes = new List<ClassificacoesViewModel>();
            listC.ForEach(a =>
            {
                classificacoes.Add(new ClassificacoesViewModel(a));
            });
            viewModel.Classificacoes = classificacoes;
            return View(viewModel);
        }

        private List<Transportadora> CarregarTransportadorasDisponíveis(int codigoUsuario)
        {
            var avaliacoesUsuario = repositorioAvaliacao.FindBy(a => a.UsuarioId == codigoUsuario);
            var todasTransportadoras = repositorioTransportadora.GetAll();
            var codigosTodas = todasTransportadoras.Select(a=>a.Id).ToList();
            
            if(avaliacoesUsuario != null && avaliacoesUsuario.Count() > 0){
                var transportadorasUsuario = avaliacoesUsuario.Select(a => a.TransportadoraId).ToList();
                var listaRetorno = todasTransportadoras.Where(a => !transportadorasUsuario.Contains(a.Id)).ToList();
                return listaRetorno;
            }
            
            return todasTransportadoras;
        }

        [HttpPost]
        public ActionResult Create(Avaliacao av)
        {
            av.UsuarioId = 1;
            repositorioAvaliacao.Insert(av);
            return RedirectToAction("Index");
        }
 
    }
}
