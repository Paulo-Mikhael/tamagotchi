// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestSharp; //Biblioteca para chamar API's
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tamagochi;
using Tamagochi.Data;
using Tamagochi.Data.DAL;
using Tamagochi.View;

namespace invoke; //namespace que contém os códigos necessários

class Program //Nome da classe que abriga o método principal
{
	static void Main(string[] args) //Método principal
	{
		var context = new TamagotchiContext();
		var dal = new MascoteDAL(context);

		var mascotes = dal.RetornaMascotes();

		foreach (var item in mascotes)
		{
			Console.WriteLine(item.Nome);
		}

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