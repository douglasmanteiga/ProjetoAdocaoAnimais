using ProjetoAdocaoAnimais.Domain.Interfaces;
using ProjetoAdocaoAnimais.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces.Repositories;

namespace ProjetoAdocaoAnimais.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        //O CRUD da Classe IRepositoryBase já está implementado
        //Por este motivo essa classe não está dando erro para implementar o CRUD
        public Usuario Login(string usuario, string senha)
        {
            return db.Usuario.Where(u => u.Login == usuario && u.Senha == senha).FirstOrDefault();
        }

        public Usuario UsuarioExistenteNoSistema(string usuario)
        {
            return db.Usuario.ToList().Where(u => u.Login == usuario).FirstOrDefault();
        }
    }
}
