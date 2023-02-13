using Microsoft.EntityFrameworkCore;
using PedraPapelTesouraLagartoSpock.Models;

namespace PedraPapelTesouraLagartoSpock.Data;

public class JogadorContext : DbContext
{
    public JogadorContext(DbContextOptions<PartidaContext> opts) : base(opts)
    {
    }

    public DbSet<Jogador> Jogadores { get; set; }
}