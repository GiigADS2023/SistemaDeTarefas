using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {
        }

        //Vai ser criado uma tabela chamada Usarios
        public DbSet<UsuarioModel> Usuarios { get; set; }
        //Vai ser criado uma tabela chamada Tarefas
        public DbSet<TarefaModel> Tarefa { get; set; }

        /*Usado para personalizar a criação do modelo de dados. 
         * No Entity Framework, você pode usar o ModelBuilder 
         * para configurar as entidades, mapeamentos, e outras 
         * configurações de modelo.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
