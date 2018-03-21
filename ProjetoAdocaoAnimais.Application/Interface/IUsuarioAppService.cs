using ProjetoAdocaoAnimais.Application.Interface.Base;
using ProjetoAdocaoAnimais.Domain.Entities;

namespace ProjetoAdocaoAnimais.Domain.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
        Usuario Login(string usuario, string senha);
        Usuario UsuarioExistenteNoSistema(string usuario);
    }
}
