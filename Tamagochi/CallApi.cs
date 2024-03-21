using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
	public class CallApi
	{
		public void PokeNames() //Método para buscar os pokemons na API pokeapi (todos os pokemons)
		{
			var client = new RestClient("https://pokeapi.co/api/v2/pokemon"); //Cliente (pokeapi)

			var request = new RestRequest("", Method.Get); //Requisição GET

			var response = client.Execute(request); //Resposta da requisição

			dynamic pokeInfo = JsonConvert.DeserializeObject(response.Content);

			if (response.StatusCode == System.Net.HttpStatusCode.OK) //Se o status code for OK
			{
				foreach (var item in pokeInfo.results)
				{
					Console.WriteLine(item["name"]);
					Console.WriteLine("");
				}
			}
			else //Se não
			{
				Console.WriteLine("A conexão falhou"); //'Printa' uma mensagem de erro
			}
		}

		public Mascote? RetornaPokemon(string pokemon)
		{
			var mascote = new Mascote();

			var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon}");

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

			return null;
		}
	}
}
