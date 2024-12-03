using Microsoft.EntityFrameworkCore;
using Solution.Finance.Domain.Entities;

namespace Solution.Finance.Application.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        DbContext Context { get; }
    }
}
