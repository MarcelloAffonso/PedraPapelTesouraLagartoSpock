using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PedraPapelTesouraLagartoSpock.Data;
using PedraPapelTesouraLagartoSpock.Dtos;
using PedraPapelTesouraLagartoSpock.Models;
using PedraPapelTesouraLagartoSpock.Models.Enum;

namespace PedraPapelTesouraLagartoSpock.Controllers;

[ApiController]
[Route("[controller]")]
public class PartidaController : ControllerBase
{
    private PartidaContext _context;
    private IMapper _mapper;

    private static Dictionary<Jogada, List<Jogada>> GanhaDe = new Dictionary<Jogada, List<Jogada>>()
    {
        { Jogada.Pedra, new List<Jogada>{ Jogada.Tesoura, Jogada.Lagarto} },
        { Jogada.Papel, new List<Jogada>{ Jogada.Pedra, Jogada.Spock} },
        { Jogada.Tesoura, new List<Jogada>{ Jogada.Papel, Jogada.Lagarto} },
        { Jogada.Lagarto, new List<Jogada>{ Jogada.Papel, Jogada.Spock} },
        { Jogada.Spock, new List<Jogada>{ Jogada.Pedra, Jogada.Tesoura} }
    };

    public PartidaController(PartidaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo jogador ao banco de dados.
    /// </summary>
    /// <param name="partidaDTO">Objeto com os campos necessários para a criação de um jogador</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja efetuada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaPartida([FromBody] CreatePartidaDTO partidaDTO)
    {
        Partida partida = _mapper.Map<Partida>(partidaDTO);
        _context.Partidas.Add(partida);
        _context.SaveChanges();
        return CreatedAtAction(nameof(DeterminaGanhador),
            new { id = partida.Id },
            partida);
    }

    /// <summary>
    /// Determina o ganhador de uma partida 
    /// </summary>
    /// <param name="id">Identificador da partida</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a partida exista no banco de dados.</response>
    /// <response code="404">Caso a partida não exista exista no banco de dados.</response>
    [HttpGet("{id}")]
    public IActionResult DeterminaGanhador(int id)
    {
        var partida = _mapper.Map<ReadPartidaDTO>(_context.Partidas.FirstOrDefault(partida => partida.Id == id));
        if (partida == null)
        {
            return NotFound();
        }
        else if (GanhaDe.TryGetValue(partida.Jogador1.Jogada, out List<Jogada>? jogada1GanhaDe) &&
            jogada1GanhaDe.Contains(partida.Jogador2.Jogada))
        {
            return Ok(_mapper.Map<ReadJogadorDTO>(partida.Jogador1));
        }
        else if (GanhaDe.TryGetValue(partida.Jogador2.Jogada, out List<Jogada>? jogada2GanhaDe) &&
            jogada2GanhaDe.Contains(partida.Jogador1.Jogada))
        {
            return Ok(_mapper.Map<ReadJogadorDTO>(partida.Jogador2));
        }

        return Ok(_mapper.Map<ReadJogadorDTO>(partida.Jogador1));
    }
}
