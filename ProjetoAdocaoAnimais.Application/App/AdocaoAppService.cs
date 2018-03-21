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
    public class AdocaoAppService : AppServiceBase<Adocao>, IAdocaoAppService
    {
        private readonly IAdocaoService _iAdocaoService;
        //Injeção de dependência de AppServiceBase
        public AdocaoAppService(IAdocaoService iAdocaoService) : base(iAdocaoService)
        {
            _iAdocaoService = iAdocaoService;
        }
    }
}
