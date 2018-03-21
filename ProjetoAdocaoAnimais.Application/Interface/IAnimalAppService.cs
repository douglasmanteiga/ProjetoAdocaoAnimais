using ProjetoAdocaoAnimais.Application.Interface.Base;
using ProjetoAdocaoAnimais.Domain.Entities;

namespace ProjetoAdocaoAnimais.Domain.Interfaces
{
    public interface IAnimalAppService : IAppServiceBase<Animal>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
    }
}