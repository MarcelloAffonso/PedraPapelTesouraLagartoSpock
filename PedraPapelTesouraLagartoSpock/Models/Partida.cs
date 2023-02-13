using System.ComponentModel.DataAnnotations;

namespace PedraPapelTesouraLagartoSpock.Models;

public class Partida
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Jogador 1 é necessário para o jogo acontecer!")]
    public Jogador Jogador1 { get; set; }

    [Required(ErrorMessage = "Jogador 2 é necessário para o jogo acontecer!")]
    public Jogador Jogador2 { get; set; }
}
