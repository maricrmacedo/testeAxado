using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using Exercicios;
using BancoDados.Entity;
using MvcApplication.ViewModels;

namespace MvcApplication.Controllers
{   
    public class TransportadorasController : Controller
    {
        private Context context;
        private Repository<Transportadora> repositorioTransportadora;

        public TransportadorasController()
        {
            context = new Context();
            var dataBaseInitializer = new DataBaseInitializer();
            dataBaseInitializer.InitializeDatabase(context);
            repositorioTransportadora = new Repository<Transportadora>(context);
        }

		public ViewResult Index()
        {
            if (User.Identity.Name == "")
                return View("../Account/Login");
            
            var transportadoras = repositorioTransportadora.GetAll();

            List<TransportadorasViewModel> listaRetorno = new List<TransportadorasViewModel>();

            if (transportadoras != null && transportadoras.Count > 0)
            {
                transportadoras.ForEach(t =>
                {
                    listaRetorno.Add(new TransportadorasViewModel(t));
                });
            }

            return View(listaRetorno);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Transportadora t)
        {
            Transportadora nova = new Transportadora();
            nova.Descricao = t.Descricao;
            repositorioTransportadora.Insert(nova);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var transportadora = repositorioTransportadora.GetById(id); 
            return View(new TransportadorasViewModel(transportadora));
        }

        [HttpPost]
        public ActionResult Edit(Transportadora t)
        {
            repositorioTransportadora.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var transportadora = repositorioTransportadora.GetById(id);
            return View(new TransportadorasViewModel(transportadora));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioTransportadora.Delete(repositorioTransportadora.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

