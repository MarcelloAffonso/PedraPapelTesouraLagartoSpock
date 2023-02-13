using System.ComponentModel.DataAnnotations;

namespace PedraPapelTesouraLagartoSpock.Dtos;

public class ReadPartidaDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Jogador 1 é necessário para o jogo acontecer!")]
    public ReadJogadorDTO Jogador1 { get; set; }

    [Required(ErrorMessage = "Jogador 2 é necessário para o jogo acontecer!")]
    public ReadJogadorDTO Jogador2 { get; set; }
}
