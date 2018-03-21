using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Entities
{
    public enum AdocaoSituacaoEnum
    {
        Adotado = 1,
        Devolvido = 2        
    }
    public class AdocaoSituacao
    {
        public int AdocaoSituacaoId { get; set; }
        public string Descricao { get; set; }
    }
}
