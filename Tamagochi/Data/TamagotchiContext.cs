﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Model;

namespace Tamagochi.Data
{
	public class TamagotchiContext : DbContext
	{
        private string ConnectionString = "Data Source=MONICA-PC\\SQLSERVER2023;Initial Catalog=Tamagotchi;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConnectionString).UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokemonsUsuario>().HasKey(item => new { item.MascoteId, item.HabilidadeId});
		}

		public DbSet<Mascote> Mascotes { get; set; }
		public DbSet<PokemonsUsuario> PokemonsUsuarios { get; set; }
		public DbSet<Ability> Habilidades { get; set; }
	}
}
