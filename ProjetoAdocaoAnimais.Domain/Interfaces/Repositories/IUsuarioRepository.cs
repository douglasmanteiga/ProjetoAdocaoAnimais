using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
        Usuario Login(string usuario, string senha);
        Usuario UsuarioExistenteNoSistema(string usuario);
    }
}
