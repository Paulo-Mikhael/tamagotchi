// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestSharp; //Biblioteca para chamar API's
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tamagochi;

namespace invoke; //namespace que contém os códigos necessários

class Program //Nome da classe que abriga o método principal
{
	static void Main(string[] args) //Método principal
	{
		var main = new MainScreen();

		main.CustomTitle("TAMAGOTCHI - BICHINHO VIRTUAL");
		Console.WriteLine("");
		Console.WriteLine("");
		var userName = main.UserName();

		while (userName == "")
		{
			Console.WriteLine("Fale seu nome");
			Console.WriteLine("");
			userName = main.UserName();
		}

		var welcome = new WelcomeScreen(userName);
		Console.Clear();
		welcome.MainMenu();
	}
}