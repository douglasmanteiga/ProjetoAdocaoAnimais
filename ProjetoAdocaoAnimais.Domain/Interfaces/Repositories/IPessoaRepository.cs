using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        //Aqui é para Implementar métodos especiais que não tem na classe IRepositoryBase
    }
}
