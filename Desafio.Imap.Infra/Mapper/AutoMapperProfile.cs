using AutoMapper;
using Desafio.Imap.Core.Entities;
using Desafio.Imap.Core.Models;

namespace Desafio.Imap.Infra.Mapper;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		this.CreateMap<Candidato, CandidatoViewModel>().ReverseMap();
        this.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
    }
}

