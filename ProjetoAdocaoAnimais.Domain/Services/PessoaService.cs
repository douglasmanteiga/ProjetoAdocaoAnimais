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
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _iPessoaRepository;

        public PessoaService(IPessoaRepository iPessoaRepository) : base(iPessoaRepository)
        {
            _iPessoaRepository = iPessoaRepository;
        }
    }    
}
