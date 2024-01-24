using Microsoft.EntityFrameworkCore;

namespace LHPet.Models
{
    public class Contexto : DbContext
    {
        //Criação de construtor
        public Contexto(DbContextOptions<Contexto>options) : base(options)
        {
            
        }

        public DbSet<Cliente> Cliente {get; set; }
    }
    
}