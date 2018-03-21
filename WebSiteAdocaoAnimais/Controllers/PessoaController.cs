using AutoMapper;
using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSiteAdocaoAnimais.Models;

namespace WebSiteAdocaoAnimais.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _iPessoaAppService;
        private readonly IAdocaoAppService _iAdocaoAppService;

        public PessoaController(IPessoaAppService iPessoaAppService,
                                IAdocaoAppService iAdocaoAppService)
        {
            _iPessoaAppService = iPessoaAppService;
            _iAdocaoAppService = iAdocaoAppService;
        }

        // GET: Pessoa
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var listItem = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_iPessoaAppService.GetAll());
                return View(listItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Pessoa/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iPessoaAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Pessoa, PessoaViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Pessoa/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(PessoaViewModel pessoaViewModel)
        {
            try
            {

                pessoaViewModel.DataHoraCadastro = DateTime.Now;

                if (ModelState.IsValid)
                {
                    var item = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);
                    _iPessoaAppService.Add(item);

                    return RedirectToAction("Index");
                }

                return View(pessoaViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Pessoa/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iPessoaAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Pessoa, PessoaViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: Pessoa/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(PessoaViewModel pessoaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var item = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);

                    _iPessoaAppService.Update(item);

                    return RedirectToAction("Index");
                }

                return View(pessoaViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Pessoa/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iPessoaAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Pessoa, PessoaViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: Pessoa/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var encontrado = _iPessoaAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var permiteExclusao = _iAdocaoAppService.GetAll().Where(a => a.Pessoa.PessoaId == encontrado.PessoaId).FirstOrDefault();

                if (permiteExclusao != null && permiteExclusao.AdocaoId > 0)
                {
                    ModelState.AddModelError("", "Existe uma adoção cadastrada para este registro, é necessário exclui-la para prosseguir com a operação!");
                    var item = Mapper.Map<Pessoa, PessoaViewModel>(encontrado);
                    return View(item);
                }

                _iPessoaAppService.Remove(encontrado);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
