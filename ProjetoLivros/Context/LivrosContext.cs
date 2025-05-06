using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{

    //  cria a heranca do seu contexto com a classe pronta DBCONTEXT
    //  E obrigatorio herdar do DbContext, classe pronta que ja configura o seu contexto
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

        //  Metodo que ja vem pronta onconfiguring que da o texto de onde e como vai ser criado o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  obrigatorio colocar sua linha de codigo de conexao com suas informacoes
            optionsBuilder.UseSqlServer("Data Source=NOTE24-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        //  classe mais importante, serve para configurar todos os tipos de dados da sua model, onmodelcreating é um metodo que tambem ja vem pronto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(

                //  entity significa "usuario"
                entity =>
                {
                    // haskey identifica a chave informada como a chave primaria
                    entity.HasKey(u => u.UsuarioId);

                    //  Property = serve para acessar uma coluna da tabela
                    //  isrequired = informa como campo obrigatorio
                    //  HasMaxLength = informa o total de caracteres que pode ter (apenas string)
                    //  IsUnicode = è um tamanho muito grande que quando for string, deixa o codigo aceitar qualquer lingua
                    //  * caso nao for usar, muito importante definir como false
                    //  HaxIndex = informa que o campo tem um indice, necessario para quando for usar IsUnique
                    //  IsUnique = Informa que so pode ter um texto daquele no banco

                    entity.Property(u => u.NomeCompleto).IsRequired().HasMaxLength(250).IsUnicode(false);
                    entity.Property(u => u.Email).IsRequired().HasMaxLength(150).IsUnicode(false);
                    entity.HasIndex(u => u.Email).IsUnique();
                    entity.Property(u => u.Senha).IsRequired().HasMaxLength(255).IsUnicode(false);
                    entity.Property(u => u.Telefone).HasMaxLength(50).IsUnicode(false);
                    entity.Property(u => u.DataCadastro).IsRequired();
                    entity.Property(u => u.DataAtualizacao).IsRequired();
                    entity.HasOne(u => u.TipoUsuario).WithMany(t => t.Usuarios).HasForeignKey(u => u.TipoUsuarioId).OnDelete(DeleteBehavior.Cascade);


                });

            //  uso o metodo moldelbuilder para informar ao entity qual tabela vou editar
            modelBuilder.Entity<TipoUsuario>(

                //  chamo a tabela em questao
                entity =>
                {
                    //  configuro a chave primaria como o tipouduarioid
                    entity.HasKey(t => t.TipoUsuarioId);
                    //  configuro a descricaotipo como campo obrigatorio, de limite de matanho sem, e sem ser unicode
                    entity.Property(t => t.DescricaoTipo).IsRequired().HasMaxLength(100).IsUnicode(false);

                    //  apos configurar a coluna, uso o haxindex para definir como um indice e
                    //  uso o metodo isunique para definir como cada texto unico
                    entity.HasIndex(t => t.DescricaoTipo).IsUnique();

                });

            modelBuilder.Entity<Livro>(
                entity =>
                {
                    entity.HasIndex(l => l.LivroId);

                    entity.Property(l => l.Titulo).IsRequired().HasMaxLength(200).IsUnicode(false);
                    entity.Property(l => l.Autor).IsRequired().HasMaxLength(200).IsUnicode(false);
                    entity.Property(l => l.Descricao).IsRequired().HasMaxLength(255).IsUnicode(false);
                    entity.Property(l => l.DataPublicacao).IsRequired();

                    entity.HasOne(l => l.Categoria).WithMany(l => l.Livros).HasForeignKey(l => l.CategoriaId).OnDelete(DeleteBehavior.Cascade);

                });

            modelBuilder.Entity<Categoria>(
                entity =>
                {
                    entity.HasIndex(c => c.CategoriaId);
                    entity.Property(c => c.NomeCategoria).IsRequired().HasMaxLength(150).IsUnicode(false);
                });

            modelBuilder.Entity<Assinatura>(
                entity => 
                { 
                    entity.HasIndex(a => a.AssinaturaId);

                    entity.Property(l => l.DataInicio).IsRequired();
                    entity.Property(l => l.DataFim).IsRequired();
                    entity.Property(l => l.Status).IsRequired().HasMaxLength(100).IsUnicode(false);
                    entity.HasOne(a => a.Usuario).WithMany(a => a.Assinaturas).HasForeignKey(a => a.UsuarioId).OnDelete(DeleteBehavior.Cascade);
                });

        }




    }


}
