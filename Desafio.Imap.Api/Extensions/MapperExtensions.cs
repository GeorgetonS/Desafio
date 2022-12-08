using AutoMapper;
using Desafio.Imap.Infra.Mapper;

namespace Desafio.Imap.Api.Extensions;

public static class MapperExtensions 
{ 
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}
