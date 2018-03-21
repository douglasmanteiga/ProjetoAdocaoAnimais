namespace ProjetoAdocaoAnimais.Infra.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoAdocaoAnimais.Infra.Data.Context.AdocaoAnimaisContext>
    {
        //Migração de dados - Enable-Migrations
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoAdocaoAnimais.Infra.Data.Context.AdocaoAnimaisContext context)
        {
            //Insere ou Atualiza as situações
            context.AdocaoSituacao.AddOrUpdate
                (a => a.AdocaoSituacaoId,
                new AdocaoSituacao { AdocaoSituacaoId = (int)AdocaoSituacaoEnum.Adotado, Descricao = AdocaoSituacaoEnum.Adotado.ToString() },
                new AdocaoSituacao { AdocaoSituacaoId = (int)AdocaoSituacaoEnum.Devolvido, Descricao = AdocaoSituacaoEnum.Devolvido.ToString() }
                );

            //Insere ou Atualiza o sexo
            context.AnimalSexo.AddOrUpdate
                (a => a.SexoId,
                new AnimalSexo { SexoId = (int)AnimalSexoEnum.Macho, Sexo = AnimalSexoEnum.Macho.ToString() },
                new AnimalSexo { SexoId = (int)AnimalSexoEnum.Femea, Sexo = AnimalSexoEnum.Femea.ToString() }
                );
        }
    }
}
