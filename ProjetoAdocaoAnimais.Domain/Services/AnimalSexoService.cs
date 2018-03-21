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
    public class AnimalSexoService : ServiceBase<AnimalSexo>, IAnimalSexoService
    {
        private readonly IAnimalSexoRepository _iAnimalSexoRepository;

        public AnimalSexoService(IAnimalSexoRepository iAnimalSexoRepository) : base(iAnimalSexoRepository)
        {
            _iAnimalSexoRepository = iAnimalSexoRepository;
        }
    }    
}
