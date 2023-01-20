using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SeaBattle.DataManagement.Models;

public partial class SeabattleContext : DbContext
{
    public SeabattleContext()
    {
    }

    public SeabattleContext(DbContextOptions<SeabattleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppLog> AppLogs { get; set; }

    public virtual DbSet<Playarea> Playareas { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<SeabattleGame> SeabattleGames { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Shoot> Shoots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=seabattle;Username=postgres;Password=734911");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("app_logs_pkey");

            entity.ToTable("app_logs");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(0)
                .HasColumnName("created");
            entity.Property(e => e.Error).HasColumnName("error");
            entity.Property(e => e.IdPlayer).HasColumnName("id_player");
            entity.Property(e => e.Information).HasColumnName("information");
            entity.Property(e => e.Path).HasColumnName("path");

            entity.HasOne(d => d.IdPlayerNavigation).WithMany(p => p.AppLogs)
                .HasForeignKey(d => d.IdPlayer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_logs_id_player_foreign");
        });

        modelBuilder.Entity<Playarea>(entity =>
        {
            entity.HasKey(e => e.IdPlayer).HasName("playareas_pkey");

            entity.ToTable("playareas");

            entity.Property(e => e.IdPlayer)
                .ValueGeneratedNever()
                .HasColumnName("id_player");

            entity.Property(e => e.ConfirmedPlayarea)
                .HasPrecision(0)
                .HasColumnName("confirmed_playarea");

            entity.Property(e => e.Playarea1).HasColumnName("playarea");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("players_pkey");

            entity.ToTable("players");

            entity.HasIndex(e => e.Name, "players_name_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SeabattleGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seabattle_games_pkey");

            entity.ToTable("seabattle_games");

            entity.HasIndex(e => e.IdSession, "seabattle_games_id_session_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.EndGame)
                .HasPrecision(0)
                .HasColumnName("end_game");
            entity.Property(e => e.GameMessage).HasColumnName("game_message");
            
            entity.Property(e => e.IdPlayerTurn).HasColumnName("id_player_turn");
            entity.Property(e => e.IdPlayerWin).HasColumnName("id_player_win");
            entity.Property(e => e.IdSession).HasColumnName("id_session");
            entity.Property(e => e.StartGame)
                .HasPrecision(0)
                .HasColumnName("start_game");

            entity.HasOne(d => d.IdPlayerTurnNavigation).WithMany(p => p.SeabattleGameIdPlayerTurnNavigations)
                .HasForeignKey(d => d.IdPlayerTurn)
                .HasConstraintName("seabattle_games_id_player_turn_foreign");

            entity.HasOne(d => d.IdPlayerWinNavigation).WithMany(p => p.SeabattleGameIdPlayerWinNavigations)
                .HasForeignKey(d => d.IdPlayerWin)
                .HasConstraintName("seabattle_games_id_player_win_foreign");

            entity.HasOne(d => d.IdSessionNavigation).WithOne(p => p.SeabattleGame)
                .HasForeignKey<SeabattleGame>(d => d.IdSession)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seabattle_games_id_session_foreign");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessions_pkey");

            entity.ToTable("sessions");

            entity.HasIndex(e => e.Name, "sessions_name_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.EndSession)
                .HasPrecision(0)
                .HasColumnName("end_session");
            entity.Property(e => e.IdPlayerHost).HasColumnName("id_player_host");
            entity.Property(e => e.IdPlayerJoin).HasColumnName("id_player_join");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StartSession)
                .HasPrecision(0)
                .HasColumnName("start_session");

            entity.HasOne(d => d.IdPlayerHostNavigation).WithMany(p => p.SessionIdPlayerHostNavigations)
                .HasForeignKey(d => d.IdPlayerHost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sessions_id_player_host_foreign");

            entity.HasOne(d => d.IdPlayerJoinNavigation).WithMany(p => p.SessionIdPlayerJoinNavigations)
                .HasForeignKey(d => d.IdPlayerJoin)
                .HasConstraintName("sessions_id_player_join_foreign");
        });

        modelBuilder.Entity<Shoot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shoots_pkey");

            entity.ToTable("shoots");

            entity.HasIndex(e => e.IdSeabattleGame, "shoots_id_seabattle_game_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdPlayerShoot).HasColumnName("id_player_shoot");
            entity.Property(e => e.IdSeabattleGame).HasColumnName("id_seabattle_game");
            entity.Property(e => e.ShootCoordinateX).HasColumnName("shoot_coordinate_X");
            entity.Property(e => e.ShootCoordinateY).HasColumnName("shoot_coordinate_Y");
            entity.Property(e => e.TimeShoot)
                .HasPrecision(0)
                .HasColumnName("time_shoot");

            entity.HasOne(d => d.IdPlayerShootNavigation).WithMany(p => p.Shoots)
                .HasForeignKey(d => d.IdPlayerShoot)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shoots_id_player_shoot_foreign");

            entity.HasOne(d => d.IdSeabattleGameNavigation).WithOne(p => p.Shoot)
                .HasForeignKey<Shoot>(d => d.IdSeabattleGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shoots_id_seabattle_game_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
