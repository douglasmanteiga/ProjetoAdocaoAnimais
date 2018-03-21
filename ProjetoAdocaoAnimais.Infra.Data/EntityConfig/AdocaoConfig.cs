using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class AdocaoConfig : EntityTypeConfiguration<Adocao>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public AdocaoConfig()
        {
            //Definindo a chave da tabela
            HasKey(a => a.AdocaoId);

            //Definindo o campo obrigatório
            Property(a => a.DataAdocao).IsRequired();
            Property(a => a.DataHoraCadastro).IsRequired();
            Property(a => a.AdocaoSituacaoId).IsRequired();
            Property(a => a.AnimalId).IsRequired();
            Property(a => a.UsuarioId).IsRequired();

            //Adicionando a Foreign key
            HasRequired(a => a.AdocaoSituacao).WithMany().HasForeignKey(a => a.AdocaoSituacaoId);
            HasRequired(a => a.Pessoa).WithMany().HasForeignKey(a => a.PessoaId);
            HasRequired(a => a.Animal).WithMany().HasForeignKey(a => a.AnimalId);
            HasRequired(a => a.Usuario).WithMany().HasForeignKey(a => a.UsuarioId);
        }
    }
}
