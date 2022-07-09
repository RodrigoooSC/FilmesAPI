using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext // Classe de controle do contexto entre nossa aplicação e o banco de dados
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
        {            
        }
        
        // Sobrescreve a implementação e não retorna nada; No momenta da criação do modelo personaliza algumas definições.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Definimos uma relação de 1:1
            builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema) // Um endereco tem um cinema
            .WithOne(cinema => cinema.Endereco) // Um cinema possui um endereco
            .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); // Chave estrangeira que liga a um endereco a um cinema ente as tabelas

            // Definimos uma relação de 1:n
            builder.Entity<Cinema>()
            .HasOne(cinema => cinema.Gerente) // Um cinema tem um gerente
            .WithMany(gerente => gerente.Cinemas) // Um gerente tem muitos cinemas
            .HasForeignKey(cinema => cinema.GerenteId); // Chave estrangeira que referencia o gerente.
        }

        public DbSet<Filme> Filmes {get; set;} // Propriedade que vai mapear de forma encapsulada os dados dos filmes.

         public DbSet<Cinema> Cinemas {get; set;} // Propriedade que vai mapear de forma encapsulada os dados dos cinemas.

         public DbSet<Endereco> Enderecos {get; set;} // Propriedade que vai mapear de forma encapsulada os dados dos enderecos.  

         public DbSet<Gerente> Gerentes {get; set;} // Propriedade que vai mapear de forma encapsulada os dados dos gerentes.        
    }
}