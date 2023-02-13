using PedraPapelTesouraLagartoSpock.Models;
using System.ComponentModel.DataAnnotations;

namespace PedraPapelTesouraLagartoSpock.Dtos;

public class CreatePartidaDTO
{
    [Required(ErrorMessage = "Jogador 1 é necessário para o jogo acontecer!")]
    public CreateJogadorDTO Jogador1 { get; set; }

    [Required(ErrorMessage = "Jogador 2 é necessário para o jogo acontecer!")]
    public CreateJogadorDTO Jogador2 { get; set; }
}
