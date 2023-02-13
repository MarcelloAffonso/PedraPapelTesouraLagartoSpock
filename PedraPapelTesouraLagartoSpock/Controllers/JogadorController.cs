using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PedraPapelTesouraLagartoSpock.Data;
using PedraPapelTesouraLagartoSpock.Dtos;
using PedraPapelTesouraLagartoSpock.Models;

namespace PedraPapelTesouraLagartoSpock.Controllers;

[ApiController]
[Route("[controller]")]
public class JogadorController : ControllerBase
{
    private JogadorContext _context;
    private IMapper _mapper;

    public JogadorController(JogadorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um jogador ao banco de dados
    /// </summary>
    /// <param name="jogadorDTO">Objeto com os campos necessários para a criação de um jogador</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AdicionaJogador([FromBody] CreateJogadorDTO jogadorDTO)
    {
        Jogador jogador = _mapper.Map<Jogador>(jogadorDTO);
        _context.Jogadores.Add(jogador);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaJogadorPorId),
            new { id = jogador.Id },
            jogador);
    }

    /// <summary>
    /// Recupera todos os jogadores do banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    [HttpGet]
    public IActionResult RecuperaJogadores()
    {
        return Ok(_context.Jogadores);
    }

    /// <summary>
    /// Recupera um jogador específico no banco de dados pelo Id
    /// </summary>
    /// <param name="id">Identificador do jogador</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o jogador exista no banco de dados.</response>
    /// <response code="404">Caso o jogador não exista exista no banco de dados.</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaJogadorPorId(int id)
    {
        var jogador = _context.Jogadores.FirstOrDefault(x => x.Id == id);
        if (jogador == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(jogador);
        }
    }
}
