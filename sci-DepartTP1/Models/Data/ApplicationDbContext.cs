using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public const string ADMIN_ROLE = "admin";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Card>().HasData(Seed.SeedCards());

        builder.Entity<IdentityUser>().HasData(Seed.SeedUsers());
        builder.Entity<IdentityRole>().HasData(Seed.SeedRoles());

        builder.Entity<IdentityUserRole<string>>().HasData(Seed.SeedUserRoles());

        builder.Entity<IdentityUser>().HasData(Seed.SeedTestUsers());
        builder.Entity<Player>().HasData(Seed.SeedTestPlayers());

        builder.Entity<StarterCard>().HasData(Seed.SeedStarterCards());
        builder.Entity<GameConfig>().HasData(Seed.SeedGameConfig());

        builder.Entity<Pack>().HasData(Seed.SeedPacks());
        builder.Entity<Probability>().HasData(Seed.SeedProbabilities());

        builder.Entity<Power>().HasData(Seed.SeedPowers());
        builder.Entity<CardPower>().HasData(Seed.SeedCardPowers());

        // Lorsque le modèle de données se complexifient, il faut éventuellement utiliser Fluent API
        // https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
        // pour préciser certaines relations.
        // Nous allons couvrir ce sujet plus tard dans la session
        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        // Fin de Fluent API
    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;

    public DbSet<StarterCard> StarterCards { get; set; } = default!;

    public DbSet<GameConfig> GameConfigs { get; set; } = default!;

    public DbSet<OwnedCard> OwnedCards { get; set; } = default!;

    public DbSet<Power> Powers { get; set; } = default!;

    public DbSet<CardPower> CardPowers { get; set; } = default!;
    public DbSet<PlayableCard> PlayableCards { get; set; } = default!;
    public DbSet<Pack> Packs { get; set; } = default!;
    public DbSet<Probability> Probabilities{ get; set; } = default!;
    public DbSet<Deck> Decks { get; set; }
}

