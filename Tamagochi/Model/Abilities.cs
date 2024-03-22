using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi.Model
{
	public class Abilities
	{
		[Key]
		public int Id {  get; set; }
		
		public List<Ability> ConjuntoHabilidades { get; set; }

		public virtual Mascote Mascote { get; set; }
	}
}
