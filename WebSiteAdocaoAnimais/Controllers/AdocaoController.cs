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
    public class AdocaoController : Controller
    {
        private readonly IAdocaoAppService _iAdocaoAppService;
        private readonly IAdocaoSituacaoAppService _iAdocaoSituacaoAppService;
        private readonly IPessoaAppService _iPessoaAppService;
        private readonly IAnimalAppService _iAnimalAppService;
        private readonly IUsuarioAppService _iUsuarioAppService;

        public AdocaoController(IAdocaoAppService iAdocaoAppService,
                                IAdocaoSituacaoAppService iAdocaoSituacaoAppService,
                                IPessoaAppService iPessoaAppService,
                                IAnimalAppService iAnimalAppService,
                                IUsuarioAppService iUsuarioAppService)
        {
            _iAdocaoAppService = iAdocaoAppService;
            _iAdocaoSituacaoAppService = iAdocaoSituacaoAppService;
            _iPessoaAppService = iPessoaAppService;
            _iAnimalAppService = iAnimalAppService;
            _iUsuarioAppService = iUsuarioAppService;
        }

        private void DadosComboBox()
        {
            try
            {
                var situacao = Mapper.Map<IEnumerable<AdocaoSituacao>, IEnumerable<AdocaoSituacaoViewModel>>(_iAdocaoSituacaoAppService.GetAll());
                var pessoa = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_iPessoaAppService.GetAll());
                var animal = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_iAnimalAppService.GetAll());

                ViewBag.Situacao = new SelectList(situacao, "AdocaoSituacaoId", "Descricao");
                ViewBag.Pessoa = new SelectList(pessoa, "PessoaId", "Nome");
                ViewBag.Animal = new SelectList(animal, "AnimalId", "Nome");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Adocao
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var listItem = Mapper.Map<IEnumerable<Adocao>, IEnumerable<AdocaoViewModel>>(_iAdocaoAppService.GetAll());
                return View(listItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Adocao/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAdocaoAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Adocao, AdocaoViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Adocao/Create
        [Authorize]
        public ActionResult Create()
        {
            DadosComboBox();
            return View();
        }

        // POST: Adocao/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(AdocaoViewModel adocaoViewModel)
        {
            try
            {
                DadosComboBox();

                var usuarioLogado = _iUsuarioAppService.UsuarioExistenteNoSistema(User.Identity.Name);

                if (usuarioLogado == null || usuarioLogado.UsuarioId <= 0)
                {
                    ModelState.AddModelError("", "O usuário logado não foi encontrado, cadastre um novo usuário e realize o login para prosseguir com a operação!");
                }
                else
                    adocaoViewModel.UsuarioId = usuarioLogado.UsuarioId;

                adocaoViewModel.DataHoraCadastro = DateTime.Now;

                if (adocaoViewModel.AdocaoSituacaoId <= 0)
                    ModelState.AddModelError("", "É necessário informar a situação!");

                if (adocaoViewModel.PessoaId <= 0)
                    ModelState.AddModelError("", "É necessário informar a pessoa!");

                if (adocaoViewModel.AnimalId <= 0)
                    ModelState.AddModelError("", "É necessário informar o animal!");

                var adocao = _iAdocaoAppService.GetAll().Where(a => a.Animal.AnimalId == adocaoViewModel.AnimalId).FirstOrDefault();

                if (adocao != null && adocao.AdocaoId > 0)
                {
                    ModelState.AddModelError("", "Já existe uma adoção para este animal, encontre o registro e realize a edição!");
                }

                if (ModelState.IsValid)
                {
                    var item = Mapper.Map<AdocaoViewModel, Adocao>(adocaoViewModel);
                    _iAdocaoAppService.Add(item);

                    return RedirectToAction("Index");
                }

                return View(adocaoViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Adocao/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                DadosComboBox();

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAdocaoAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Adocao, AdocaoViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: Adocao/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(AdocaoViewModel adocaoViewModel)
        {
            try
            {
                DadosComboBox();

                var usuarioLogado = _iUsuarioAppService.UsuarioExistenteNoSistema(User.Identity.Name);

                if (usuarioLogado == null || usuarioLogado.UsuarioId <= 0)
                {
                    ModelState.AddModelError("", "O usuário logado não foi encontrado, cadastre um novo usuário e realize o login para prosseguir com a operação!");
                }

                adocaoViewModel.UsuarioId = usuarioLogado.UsuarioId;


                if (ModelState.IsValid)
                {

                    var item = Mapper.Map<AdocaoViewModel, Adocao>(adocaoViewModel);

                    _iAdocaoAppService.Update(item);

                    return RedirectToAction("Index");
                }

                return View(adocaoViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Adocao/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAdocaoAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Adocao, AdocaoViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: Adocao/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var encontrado = _iAdocaoAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }


                _iAdocaoAppService.Remove(encontrado);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}