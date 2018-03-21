using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public UsuarioConfig()
        {
            //Definindo a chave da tabela
            HasKey(u => u.UsuarioId);

            Property(u => u.Login).IsRequired();
            Property(u => u.Senha).IsRequired();
        }
    }
}
