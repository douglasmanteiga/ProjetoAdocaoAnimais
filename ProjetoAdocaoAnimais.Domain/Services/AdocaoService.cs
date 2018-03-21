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
    public class AdocaoService : ServiceBase<Adocao>, IAdocaoService
    {
        private readonly IAdocaoRepository _iAdocaoRepository;

        public AdocaoService(IAdocaoRepository adocaoRepository) : base(adocaoRepository)
        {
            _iAdocaoRepository = adocaoRepository;
        }
    }
}
