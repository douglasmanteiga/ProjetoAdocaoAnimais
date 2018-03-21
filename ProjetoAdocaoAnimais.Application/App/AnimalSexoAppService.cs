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
    public class AnimalSexoAppService : AppServiceBase<AnimalSexo>, IAnimalSexoAppService
    {
        private readonly IAnimalSexoService _iAnimalSexoService;
        //Injeção de dependência de AppServiceBase
        public AnimalSexoAppService(IAnimalSexoService iAnimalSexoService) : base(iAnimalSexoService)
        {
            _iAnimalSexoService = iAnimalSexoService;
        }
    }
}
