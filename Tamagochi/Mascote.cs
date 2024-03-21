using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
	public class Mascote
	{
		public string Nome { get; set; }

		public int Peso { get; set; }

		public int Altura { get; set; }

		public List<object?> Habilidades { get; set; }
	} 
}
