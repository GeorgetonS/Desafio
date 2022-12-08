using Desafio.Imap.Core.Entities;
using Desafio.Imap.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Imap.Infra.Context;

public class MyContext : DbContext
{
    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidatoMap).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
