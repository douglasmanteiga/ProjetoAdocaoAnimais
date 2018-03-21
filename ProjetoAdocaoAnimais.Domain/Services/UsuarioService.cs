using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories;
using ProjetoAdocaoAnimais.Domain.Interfaces.Services;
using ProjetoAdocaoAnimais.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioService(IUsuarioRepository iUsuarioRepository) : base(iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        public Usuario Login(string usuario, string senha)
        {
            return _iUsuarioRepository.Login(usuario, senha);
        }

        public Usuario UsuarioExistenteNoSistema(string usuario)
        {
            return _iUsuarioRepository.UsuarioExistenteNoSistema(usuario);
        }
    }
}
