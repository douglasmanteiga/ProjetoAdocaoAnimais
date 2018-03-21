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
    public class AdocaoSituacaoAppService : AppServiceBase<AdocaoSituacao>, IAdocaoSituacaoAppService
    {
        private readonly IAdocaoSituacaoService _iAdocaoSituacaoService;
        //Injeção de dependência de AppServiceBase
        public AdocaoSituacaoAppService(IAdocaoSituacaoService iAdocaoSituacaoService) : base(iAdocaoSituacaoService)
        {
            _iAdocaoSituacaoService = iAdocaoSituacaoService;
        }
    }
}
