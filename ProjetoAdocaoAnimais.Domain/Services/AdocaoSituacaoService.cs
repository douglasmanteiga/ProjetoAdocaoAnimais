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
    public class AdocaoSituacaoService : ServiceBase<AdocaoSituacao>, IAdocaoSituacaoService
    {
        private readonly IAdocaoSituacaoRepository _iAdocaoSituacaoRepository;

        public AdocaoSituacaoService(IAdocaoSituacaoRepository iAdocaoSituacaoRepository) : base(iAdocaoSituacaoRepository)
        {
            _iAdocaoSituacaoRepository = iAdocaoSituacaoRepository;
        }
    }

}
