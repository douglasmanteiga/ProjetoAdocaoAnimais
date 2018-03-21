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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _iUsuarioAppService;
        private readonly IAdocaoAppService _iAdocaoAppService;

        public UsuarioController(IUsuarioAppService iUsuarioAppService,
                                IAdocaoAppService iAdocaoAppService)
        {
            _iUsuarioAppService = iUsuarioAppService;
            _iAdocaoAppService = iAdocaoAppService;
        }

        // GET: Usuario
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var listItem = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_iUsuarioAppService.GetAll());
                return View(listItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Usuario/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iUsuarioAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Usuario, UsuarioViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Usuario/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (usuarioViewModel != null && string.IsNullOrEmpty(usuarioViewModel.Login) == false)
                {
                    if (_iUsuarioAppService.UsuarioExistenteNoSistema(usuarioViewModel.Login) != null)
                    {
                        ModelState.AddModelError("", "O nome de usuário informado já existe no sistema.");
                    }
                }

                if (ModelState.IsValid)
                {
                    var item = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
                    _iUsuarioAppService.Add(item);

                    return RedirectToAction("Index");
                }

                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        public ActionResult CreateUsuarioNaoLogado()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateUsuarioNaoLogado(string usuario, string senha, string confirmarSenha)
        {
            try
            {
                string retorno = string.Empty;

                if (string.IsNullOrEmpty(usuario) == true)
                {
                    retorno = "É necessário informar o nome do usuário.";
                }
                else if (string.IsNullOrEmpty(senha) == true)
                {
                    retorno = "É necessário informar a senha.";
                }
                else if (string.IsNullOrEmpty(confirmarSenha) == true)
                {
                    retorno = "É necessário confirmar a senha.";
                }
                else if (senha != confirmarSenha)
                {
                    retorno = "As senhas informadas não conferem.";
                }
                else if(usuario.Length < 2)
                {
                    retorno = "O campo usuário precisa ter no mínimo de 2 caracteres";
                }
                else if (senha.Length < 6)
                {
                    retorno = "O campo senha precisa ter no mínimo de 6 caracteres";
                }

                else if (_iUsuarioAppService.UsuarioExistenteNoSistema(usuario) != null)
                {
                    retorno = "O nome de usuário informado já existe no sistema.";
                }
                else
                {
                    UsuarioViewModel novoUsuario = new UsuarioViewModel();
                    novoUsuario.Login = usuario;
                    novoUsuario.Senha = senha;

                    var viewModel = Mapper.Map<UsuarioViewModel, Usuario>(novoUsuario);
                    _iUsuarioAppService.Add(viewModel);

                    retorno = "Sucess";
                }


                return Json(new { Mensagem = retorno }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Usuario/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iUsuarioAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Usuario, UsuarioViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: Usuario/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var item = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

                    _iUsuarioAppService.Update(item);

                    return RedirectToAction("Index");
                }

                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Usuario/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iUsuarioAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Usuario, UsuarioViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: Usuario/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var encontrado = _iUsuarioAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var permiteExclusao = _iAdocaoAppService.GetAll().Where(a => a.Usuario.UsuarioId == encontrado.UsuarioId).FirstOrDefault();

                if (permiteExclusao != null && permiteExclusao.AdocaoId > 0)
                {
                    ModelState.AddModelError("", "Existe uma adoção cadastrada para este registro, é necessário exclui-la para prosseguir com a operação!");
                    var item = Mapper.Map<Usuario, UsuarioViewModel>(encontrado);
                    return View(item);
                }

                _iUsuarioAppService.Remove(encontrado);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}