using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAdocaoAnimais.Infra.Data.Context
{
    public class AdocaoAnimaisContext : DbContext
    {
        public AdocaoAnimaisContext() : base("ConexaoAdocaoAnimais")//Encontra a conexão ConexaoAdocaoAnimais no arquivo (Web.config)
        {

        }
        public DbSet<Adocao> Adocao { get; set; }
        public DbSet<AdocaoSituacao> AdocaoSituacao { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalSexo> AnimalSexo { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Remove a criação de tabelas no plural
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Não deleta em cascata qnd estiver uma relação de um para N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Não deleta em cascada qnd estiver uma relação de N para N

            //Quando a propriedade tiver o final com id -> Será a chave primária da tabela
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            //Quando a propriedade for string -> Utilize varchar no banco de dados
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Quando a propriedade for string -> Utilize no banco varchar(250)
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));

            //Aplicando as configurações das tabelas
            modelBuilder.Configurations.Add(new AdocaoConfig());
            modelBuilder.Configurations.Add(new AdocaoSituacaoConfig());
            modelBuilder.Configurations.Add(new AnimalConfig());
            modelBuilder.Configurations.Add(new AnimalSexoConfig());
            modelBuilder.Configurations.Add(new PessoaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //Quando for Salvar analisa a propriedade DataHoraCadastro 
            //Se o usuário estiver Inserindo seta a data e hora atual
            //Se estiver alterando não altera a data e hora

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHoraCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHoraCadastro").IsModified = false;
                }
            }

            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UsuarioId") != null))
            //{
            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("UsuarioId").IsModified = false;
            //    }
            //}

            return base.SaveChanges();
        }
    }
}
