using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class AdocaoSituacaoConfig : EntityTypeConfiguration<AdocaoSituacao>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public AdocaoSituacaoConfig()
        {
            //Definindo a chave da tabela
            HasKey(a => a.AdocaoSituacaoId);

            //Definindo o campo obrigatório
            Property(e => e.Descricao).IsRequired();
        }
    }
}
