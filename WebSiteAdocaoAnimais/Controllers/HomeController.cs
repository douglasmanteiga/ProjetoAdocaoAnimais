using ProjetoAdocaoAnimais.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSiteAdocaoAnimais.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public HomeController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            try
            {

                //Se tiver autenticado joga para index..
                if (Request.IsAuthenticated)
                {
                    //Consulta se o usuário logado existe.. 
                    var usuarioLogado = _usuarioAppService.UsuarioExistenteNoSistema(User.Identity.Name);

                    //Se não encontrou faz logoff
                    if (usuarioLogado == null || usuarioLogado.UsuarioId <= 0)
                    {
                        LogOff();
                    }

                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Login com Json
        [AllowAnonymous]
        [HttpPost]
        public JsonResult ValidarUsuario(string login, string senha)
        {
            try
            {
                string mensagem = string.Empty;

                if (string.IsNullOrWhiteSpace(login) == false && string.IsNullOrWhiteSpace(senha) == false)
                {
                    var usuarioLogin = _usuarioAppService.Login(login, senha);

                    if (usuarioLogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(login, false);
                        return Json(new { Mensagem = "Sucess" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Mensagem = "Usuário ou senha inválidos." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Mensagem = "Informe o usuário e senha." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [Authorize]
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}