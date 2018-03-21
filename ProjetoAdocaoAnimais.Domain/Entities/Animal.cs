using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Entities
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public int SexoId { get; set; }
        public virtual AnimalSexo AnimalSexo { get; set; }
        public string Peso { get; set; }
        public DateTime DataEntrada { get; set; }

    }
}
