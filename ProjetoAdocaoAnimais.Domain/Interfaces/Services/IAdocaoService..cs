using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Interfaces.Services
{
    public interface IAdocaoService : IServiceBase<Adocao>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
    }
}
