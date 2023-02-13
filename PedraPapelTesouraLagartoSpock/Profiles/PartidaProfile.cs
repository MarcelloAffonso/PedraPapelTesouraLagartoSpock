using AutoMapper;
using PedraPapelTesouraLagartoSpock.Dtos;
using PedraPapelTesouraLagartoSpock.Models;

namespace PedraPapelTesouraLagartoSpock.Profiles;

public class PartidaProfile : Profile
{
    public PartidaProfile()
    {
        CreateMap<CreatePartidaDTO, Partida>();
        CreateMap<CreateJogadorDTO, Jogador>();
        CreateMap<Partida, ReadPartidaDTO>();
        CreateMap<Jogador, ReadJogadorDTO>();
    }
}
