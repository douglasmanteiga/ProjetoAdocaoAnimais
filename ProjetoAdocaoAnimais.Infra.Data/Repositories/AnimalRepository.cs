using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories;
using ProjetoAdocaoAnimais.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        //O CRUD da Classe IRepositoryBase já está implementado
        //Por este motivo essa classe não está dando erro para implementar o CRUD
    }
}
