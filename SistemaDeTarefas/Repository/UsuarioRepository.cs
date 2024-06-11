using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interface;

namespace SistemaDeTarefas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepository(SistemaTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorID(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscarPorID(id);
            
            if (usuarioPorID == null)
            {
                throw new Exception($"Usuário para o ID: {id}, não foi encontrado no banco de dados.");
            }
                usuarioPorID.Name = usuario.Name;
                usuarioPorID.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorID);
            await _dbContext.SaveChangesAsync();

            return usuarioPorID;
        }

        public async Task<bool> ApagarUsuario(int id)
        {
            UsuarioModel usuarioPorID = await BuscarPorID(id);

            if(usuarioPorID == null)
            {
                throw new Exception($"Usuário para o ID:  {id}, não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
