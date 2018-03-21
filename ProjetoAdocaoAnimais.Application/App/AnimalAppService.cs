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
    public class AnimalAppService : AppServiceBase<Animal>, IAnimalAppService
    {
        private readonly IAnimalService _iAnimalService;
        //Injeção de dependência de AppServiceBase
        public AnimalAppService(IAnimalService iAnimalService) : base(iAnimalService)
        {
            _iAnimalService = iAnimalService;
        }
    }
}
