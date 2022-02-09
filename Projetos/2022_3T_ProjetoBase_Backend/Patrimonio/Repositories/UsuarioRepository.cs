using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            //Encontrando algum usuário que exista através do email
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                // criptorafar caso esteja descriptografado
                if (usuario.Senha.Length < 32)
                {
                    var novaSenha = Criptografia.GerarHash(usuario.Senha);

                    usuario.Senha = novaSenha;

                    ctx.Usuarios.Update(usuario);

                    ctx.SaveChanges();

                }
                //Com o usuario encontrado, temos a hash do banco para poder comparar com a senha vinda do formulário
                bool comparado = Criptografia.Comparar(senha, usuario.Senha);
                if (comparado)
                {
                    return usuario;
                }
            }

            return null;
            //return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
