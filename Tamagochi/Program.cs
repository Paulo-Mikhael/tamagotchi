// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestSharp; //Biblioteca para chamar API's
using System.ComponentModel;
using Tamagochi;

namespace invoke; //namespace que contém os códigos necessários

class Program //Nome da classe que abriga o método principal
{
	static void Main(string[] args) //Método principal
	{
		MainScreen main = new MainScreen();
		
		var mascote = RetornaPokemon();
		
		main.Titulo();
	}

	private static void PokeInfos() //Método para buscar os pokemons na API pokeapi (todos os pokemons)
	{
		var client = new RestClient("https://pokeapi.co/api/v2/pokemon"); //Cliente (pokeapi)

		var request = new RestRequest("", Method.Get); //Requisição GET

		var response = client.Execute(request); //Resposta da requisição

		if (response.StatusCode == System.Net.HttpStatusCode.OK) //Se o status code for OK
		{
			Console.WriteLine(response.Content); //'Printa' as informações
		}
		else //Se não
		{
			Console.WriteLine("A conexão falhou"); //'Printa' uma mensagem de erro
		}
	}

	private static Mascote? RetornaPokemon()
	{
		var mascote = new Mascote();

		var client = new RestClient("https://pokeapi.co/api/v2/pokemon/bulbasaur");

		var request = new RestRequest("", Method.Get);

		var response = client.Execute(request);

		if (response.StatusCode == System.Net.HttpStatusCode.OK)
		{
			dynamic pokeInfo = JsonConvert.DeserializeObject(response.Content);

			mascote.Nome = pokeInfo.forms[0]["name"];
			mascote.Peso = pokeInfo.weight;
			mascote.Altura = pokeInfo.height;

			mascote.Habilidades = new List<object?>(); //Inicializa uma nova lista de objetos

			foreach (var item in pokeInfo.abilities)
			{
				mascote.Habilidades.Add(item["ability"]["name"]); //Coloca os itens pegos em Habilidades
			}

			Console.WriteLine($"Nome: {mascote.Nome}");
			Console.WriteLine($"Peso: {mascote.Peso}");
			Console.WriteLine($"Altura: {mascote.Altura}");
			Console.WriteLine("Habilidades:");

			foreach (var habilidade in mascote.Habilidades)
			{
				Console.WriteLine(habilidade);
				return mascote;
			}
		}
		else
		{
			Console.WriteLine("A conexão falhou");
		}
		return null;
	}
}