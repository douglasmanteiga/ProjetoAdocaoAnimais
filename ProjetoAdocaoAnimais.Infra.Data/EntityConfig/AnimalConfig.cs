using ProjetoAdocaoAnimais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.EntityConfig
{
    public class AnimalConfig : EntityTypeConfiguration<Animal>
    {
        //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API
        public AnimalConfig()
        {
            //Definindo a chave da tabela
            HasKey(a => a.AnimalId);

            //Definindo o campo obrigatório
            Property(a => a.Nome).IsRequired();
            Property(a => a.Raca).IsRequired();
            Property(a => a.Cor).IsRequired();
            Property(a => a.SexoId).IsRequired();
            Property(a => a.Peso).IsRequired();
            Property(a => a.DataEntrada).IsRequired();

            //Adicionando a Foreign key
            HasRequired(a => a.AnimalSexo).WithMany().HasForeignKey(a => a.SexoId);
        }
    }
}
