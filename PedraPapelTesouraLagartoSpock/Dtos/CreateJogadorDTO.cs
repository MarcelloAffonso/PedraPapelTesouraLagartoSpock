using PedraPapelTesouraLagartoSpock.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace PedraPapelTesouraLagartoSpock.Dtos;

public class CreateJogadorDTO
{
    [Required(ErrorMessage = "O nome do jogador é obrigatório!")]
    [MaxLength(10, ErrorMessage = "O nome do jogador deve ter no máximo 10 caracteres!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Jogada é necessáriapara que o jogador possa jogar a partida!")]
    public Jogada Jogada { get; set; }
}
