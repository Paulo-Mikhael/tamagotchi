﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi.Model
{
	public class Ability
	{
		[Key]
		public int Id { get; set; }

		public string Nome { get; set; }

		public virtual List<PokemonsUsuario?> PokemonsUsuario { get; set; }
	}
}
