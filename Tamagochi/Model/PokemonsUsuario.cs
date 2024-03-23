using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi.Model
{
	public class PokemonsUsuario
	{
		[Required]
		public int MascoteId { get; set; }
		public virtual Mascote? Mascote { get; set; }

		[Required]
		public int HabilidadeId { get; set; }
		public virtual Ability? Habilidade { get; set; }
	}
}
