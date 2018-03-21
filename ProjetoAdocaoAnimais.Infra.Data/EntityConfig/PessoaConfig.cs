using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class PessoaConfig : EntityTypeConfiguration<Pessoa>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public PessoaConfig()
        {
            //Definindo a chave da tabela
            HasKey(p => p.PessoaId);
            
            //Definindo o campo obrigatório e tamanho máximo
            Property(p => p.Nome).IsRequired().HasMaxLength(500);
            Property(p => p.RG).HasMaxLength(20);
            Property(p => p.CPF).HasMaxLength(20);
            Property(p => p.DataHoraCadastro).IsRequired();

            //O campo e-mail é obrigatório porém seu tamhno é 250, isso foi definido como padrão no OnModelCreating (DbContext)
            Property(p => p.Email).IsRequired();
        }
    }
}
