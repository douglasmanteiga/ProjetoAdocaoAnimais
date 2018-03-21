using ProjetoAdocaoAnimais.Application.App;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories;
using ProjetoAdocaoAnimais.Domain.Interfaces.Services;
using ProjetoAdocaoAnimais.Domain.Services;
using ProjetoAdocaoAnimais.Infra.Data.Context;
using ProjetoAdocaoAnimais.Infra.Data.Repositories;
using SimpleInjector;

namespace ProjetoAdocaoAnimais.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        //Aqui utilizamos - Inversion Of Control - Inversão de Controle:
        //Suportar o padrão de interações entre as quatro camadas através de uma estrutura arquitetônica.
        //Aplicação, Serviços Infraestrutura, e Repositório utilizam o framework de IoC
        public static void Register(Container container)
        {
            //Lifestyle.Scoped = Uma instância por request
            container.Register<AdocaoAnimaisContext>(Lifestyle.Scoped);

            container.Register<IAdocaoAppService, AdocaoAppService>(Lifestyle.Scoped);
            container.Register<IAdocaoService, AdocaoService>(Lifestyle.Scoped);
            container.Register<IAdocaoRepository, AdocaoRepository>(Lifestyle.Scoped);

            container.Register<IAdocaoSituacaoAppService, AdocaoSituacaoAppService>(Lifestyle.Scoped);
            container.Register<IAdocaoSituacaoService, AdocaoSituacaoService>(Lifestyle.Scoped);
            container.Register<IAdocaoSituacaoRepository, AdocaoSituacaoRepository>(Lifestyle.Scoped);

            container.Register<IAnimalAppService, AnimalAppService>(Lifestyle.Scoped);
            container.Register<IAnimalService, AnimalService>(Lifestyle.Scoped);
            container.Register<IAnimalRepository, AnimalRepository>(Lifestyle.Scoped);

            container.Register<IAnimalSexoAppService, AnimalSexoAppService>(Lifestyle.Scoped);
            container.Register<IAnimalSexoService, AnimalSexoService>(Lifestyle.Scoped);
            container.Register<IAnimalSexoRepository, AnimalSexoRepository>(Lifestyle.Scoped);

            container.Register<IPessoaAppService, PessoaAppService>(Lifestyle.Scoped);
            container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);

            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

        }
    }
}
