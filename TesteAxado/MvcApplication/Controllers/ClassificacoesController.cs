using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using Exercicios;
using MvcApplication.ViewModels;
using BancoDados.Entity;

namespace MvcApplication.Controllers
{   
    public class ClassificacoesController : Controller
    {
        private Context context;
        private Repository<Classificacao> repClassificacao;

        public ClassificacoesController()
        {
            context = new Context();
            var dataBaseInitializer = new DataBaseInitializer();
            dataBaseInitializer.InitializeDatabase(context);
            repClassificacao = new Repository<Classificacao>(context);
        }

		public ViewResult Index()
        {
            if (User.Identity.Name == "")
                return View("../Account/Login");
            
            var lista = repClassificacao.GetAll();

            List<ClassificacoesViewModel> listaRetorno = new List<ClassificacoesViewModel>();

            if (lista != null && lista.Count > 0)
            {
                lista.ForEach(t =>
                {
                    listaRetorno.Add(new ClassificacoesViewModel(t));
                });
            }

            return View(listaRetorno);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Classificacao c)
        {
            repClassificacao.Insert(c);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var item = repClassificacao.GetById(id); 
            return View(new ClassificacoesViewModel(item));
        }

        [HttpPost]
        public ActionResult Edit(Classificacao c)
        {
            repClassificacao.Update(c);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = repClassificacao.GetById(id);
            return View(new ClassificacoesViewModel(item));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repClassificacao.Delete(repClassificacao.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

