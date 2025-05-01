using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{

    //  cria a heranca do seu contexto com a classe pronta DBCONTEXT
    public class LivrosContext : DbContext
    {
        //  cria um tipo dbset para cada uma das suas models
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Assinatura> Assinatura { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // cria um construtor para injetar o conteudo do dbcontextoption na heranca
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {

        }

        //  funcao que ja vem pronta onconfiguring que da o texto de onde e como vai ser criado o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NOTE24-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        //  classe mais importante, configura todos os tipos de dados da sua model, onmodelcreating é um metodo que tambem ja vem pronto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(

                entity =>
                {
                    entity.HasKey(u => u.UsuarioId);

                    entity.Property(u => u.NomeCompleto).IsRequired().HasMaxLength(250).IsUnicode(false);
                    entity.Property(u => u.Email).IsRequired().HasMaxLength(150).IsUnicode(false);
                    entity.HasIndex(u => u.Email).IsUnique();
                    entity.Property(u => u.Senha).IsRequired().HasMaxLength(255).IsUnicode(false);
                    entity.Property(u => u.Telefone).HasMaxLength(50).IsUnicode(false);
                    entity.Property(u => u.DataCadastro).IsRequired();
                    entity.Property(u => u.DataAtualizacao).IsRequired();
                    entity.HasOne(u => u.TipoUsuario).WithMany(t => t.Usuarios).HasForeignKey(u => u.TipoUsuarioId).OnDelete(DeleteBehavior.Cascade);


                }



                );
        }




    }


}
