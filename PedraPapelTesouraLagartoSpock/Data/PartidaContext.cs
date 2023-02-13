using Microsoft.EntityFrameworkCore;
using PedraPapelTesouraLagartoSpock.Models;

namespace PedraPapelTesouraLagartoSpock.Data;

public class PartidaContext : DbContext
{
	public PartidaContext(DbContextOptions<PartidaContext> opts) : base(opts)
	{
	}

	public DbSet<Partida> Partidas { get; set; }

	public DbSet<Jogador> Jogadores { get; set; }
}
