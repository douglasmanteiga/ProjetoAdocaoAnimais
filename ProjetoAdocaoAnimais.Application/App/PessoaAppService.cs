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
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _iPessoaService;
        //Injeção de dependência de AppServiceBase
        public PessoaAppService(IPessoaService iPessoaService) : base(iPessoaService)
        {
            _iPessoaService = iPessoaService;
        }
    }
}
