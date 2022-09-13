using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
        public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var planoContasModel  = new PlanoContaModel();
            ViewBag.Lista = planoContasModel.ListaPlanoContas();

            return View();
        }
        [HttpGet]
        public IActionResult CriarPlanoConta(int? id){
            if (id != null){
            var planoConta = new PlanoContaModel().CarregarPlanoContaPorId(id);
            ViewBag.PlanoConta = planoConta;
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel formulario){

            if(formulario.Id == null)
            formulario.Inserir();
            else 
            formulario.Atualizar(formulario.Id);

            return RedirectToAction("Index");
            
        }
        
        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id){

             new PlanoContaModel().Excluir(id);
            return RedirectToAction("Index");
        }
        

        }
}