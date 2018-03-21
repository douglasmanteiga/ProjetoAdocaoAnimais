using ProjetoAdocaoAnimais.Application.Interface.Base;
using ProjetoAdocaoAnimais.Domain.Entities;

namespace ProjetoAdocaoAnimais.Domain.Interfaces
{
    public interface IAdocaoAppService : IAppServiceBase<Adocao>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
    }
}
