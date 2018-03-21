using ProjetoAdocaoAnimais.Application.App.Base;
using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using ProjetoAdocaoAnimais.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Application.App
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _iUsuarioService;
        //Injeção de dependência
        public UsuarioAppService(IUsuarioService iUsuarioService) : base(iUsuarioService)
        {
            _iUsuarioService = iUsuarioService;
        }

        public Usuario Login(string usuario, string senha)
        {
            return _iUsuarioService.Login(usuario, senha);
        }

        public Usuario UsuarioExistenteNoSistema(string usuario)
        {
            return _iUsuarioService.UsuarioExistenteNoSistema(usuario);
        }
    }
}
