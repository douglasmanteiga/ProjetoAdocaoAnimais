using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Domain.Entities
{
    public class Adocao
    {
        public int AdocaoId { get; set; }
        public DateTime DataAdocao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int AdocaoSituacaoId { get; set; }
        public virtual AdocaoSituacao AdocaoSituacao { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
