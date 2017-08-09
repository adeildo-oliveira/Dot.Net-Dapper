using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProjetoArquivoLinks.Aplication.Interfaces;
using ProjetoArquivoLinks.Aplication.ViewModels;

namespace ProjetoArquivaLink.UI.MVC.Controllers
{
    public class LinkController : Controller, IDisposable
    {
        private readonly ILinkAppService _linkAppService;

        public LinkController(ILinkAppService linkAppService)
        {
            _linkAppService = linkAppService;
        }

        public ActionResult Index(string filtro, int? Pagina)
        {
            if (Request.IsAjaxRequest())
            {
                int pageSize = 10;
                int pageNumber = (Pagina ?? 1);
                var linkPagination = new LinkViewModel
                {
                    Url = filtro,
                    DescricaoLink = filtro
                };
                
                var linksCadastrados = _linkAppService.PaginationFiltro(linkPagination, pageSize, pageNumber);
                return Json(linksCadastrados, JsonRequestBehavior.AllowGet);
            }
            
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet, ActionName("CadastrarLink")]
        public ActionResult Create()
        {
            return PartialView("_CadastrarLink");
        }

        [HttpPost, ActionName("CadastrarLink")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LinkViewModel linkViewModel)
        {
            if (ModelState.IsValid)
            {
                _linkAppService.Add(linkViewModel);
                ViewBag.Mensage = "Cadastro efetuado com sucesso!";

                return PartialView("_CadastrarLink");
            }

            return PartialView("_CadastrarLink", linkViewModel);
        }

        [HttpGet, ActionName("EditarLink")]
        public ActionResult Edit(Guid IdLink)
        {
            return PartialView("_EditarLink", _linkAppService.GetById(IdLink));
        }

        [HttpPost, ActionName("EditarLink")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LinkViewModel linkViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _linkAppService.Update(linkViewModel);
                    ViewBag.Mensage = "Atualização efetuada com sucesso!";

                    return PartialView("_EditarLink");
                }

                return PartialView("_EditarLink", linkViewModel);
            }
            catch(Exception erro)
            {
                return View(erro);
            }
        }

        [HttpGet, ActionName("ExcluirLink")]
        public ActionResult Delete(Guid IdLink)
        {
            return PartialView("_ExcluirLink", _linkAppService.GetById(IdLink));
        }
        
        [HttpPost, ActionName("ExcluirLink")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(Guid IdLink)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _linkAppService.Remove(IdLink);
                    ViewBag.Mensage = "Atualização efetuada com sucesso!";

                    return RedirectToAction("Index", "Link");
                }

                return PartialView("_ExcluirLink", _linkAppService.GetById(IdLink));
            }
            catch (Exception erro)
            {
                return View(erro);
            }
        }

        public new void Dispose()
        {
            _linkAppService.Dispose();
        }
    }
}
