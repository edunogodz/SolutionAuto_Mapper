using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Config
{
    public class ContextBase1 : DbContext
    {
        public ContextBase1(DbContextOptions<ContextBase1> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<ItemTarefa> ItemTarefa { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConect());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetStringConect()
        {
            //return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=dbTarefas2022;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbTarefas2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

    }
}
