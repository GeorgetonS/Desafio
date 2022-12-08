using AutoMapper;
using Desafio.Imap.Api.Entities;
using Desafio.Imap.Api.Models;

namespace Desafio.Imap.Api.Mapper;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		this.CreateMap<Candidato, CandidatoViewModel>().ReverseMap();
        this.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
    }
}

