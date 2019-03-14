﻿// <auto-generated />
using System;
using BlackJack.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJack.DataAccess.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rank");

                    b.Property<int>("Suit");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.GamePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsBot");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundGamePlayerCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CardId");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GamePlayerId");

                    b.Property<int?>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("GamePlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("RoundGamePlayerCards");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.GamePlayer", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId");

                    b.HasOne("BlackJack.DataAccess.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Round", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundGamePlayerCard", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("BlackJack.DataAccess.Entities.GamePlayer", "GamePlayer")
                        .WithMany()
                        .HasForeignKey("GamePlayerId");

                    b.HasOne("BlackJack.DataAccess.Entities.Round", "Round")
                        .WithMany("RoundGamePlayerCards")
                        .HasForeignKey("RoundId");
                });
#pragma warning restore 612, 618
        }
    }
}
