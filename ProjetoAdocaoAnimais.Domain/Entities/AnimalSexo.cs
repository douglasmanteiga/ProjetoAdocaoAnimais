using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Entities
{
    public enum AnimalSexoEnum
    {
        Macho = 1,
        Femea = 2
    }
    public class AnimalSexo
    {
        public int SexoId { get; set; }
        public string Sexo { get; set; }
    }
}
