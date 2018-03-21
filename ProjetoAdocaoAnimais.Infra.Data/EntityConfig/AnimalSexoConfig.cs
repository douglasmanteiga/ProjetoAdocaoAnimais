using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class AnimalSexoConfig : EntityTypeConfiguration<AnimalSexo>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public AnimalSexoConfig()
        {
            //Definindo a chave da tabela
            HasKey(a => a.SexoId);

            //Definindo o campo obrigatório
            Property(e => e.Sexo).IsRequired();
        }
    }
}
