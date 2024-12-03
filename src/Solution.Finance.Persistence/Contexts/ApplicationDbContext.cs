using Microsoft.EntityFrameworkCore;
using Solution.Finance.Application.Interfaces.Persistence;
using Solution.Finance.Domain.Entities;

namespace Solution.Finance.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbContext Context => this;

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
