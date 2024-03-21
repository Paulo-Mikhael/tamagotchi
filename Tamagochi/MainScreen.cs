using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
	public class MainScreen
	{
		public void CustomTitle(string text)
		{
			var caracteres = text.Length;

			for (int i = 0; i < caracteres; i++)
			{
				Console.Write("#");
			}

			Console.WriteLine("\r\n"+text);

			for (int i = 0; i < caracteres; i++)
			{
				Console.Write("#");
			}
		}

		public string UserName()
		{
			Console.WriteLine("Qual é seu nome?");
			var userName = Console.ReadLine();

			return userName;
		}
	}
}
