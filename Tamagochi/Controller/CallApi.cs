﻿using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Data;
using Tamagochi.Data.DAL;
using Tamagochi.Model;

namespace Tamagochi.Controller
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

            var conjuntoHabilidades = new PokemonsUsuario();

            var context = new TamagotchiContext();

            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon}");

            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dynamic pokeInfo = JsonConvert.DeserializeObject(response.Content);

                mascote.Nome = pokeInfo.forms[0]["name"];
                mascote.Peso = pokeInfo.weight;
                mascote.Altura = pokeInfo.height;

				Console.WriteLine($"Nome: {mascote.Nome.ToUpper()}");
                Console.WriteLine($"Peso: {mascote.Peso}");
                Console.WriteLine($"Altura: {mascote.Altura}");
                Console.WriteLine("");
                Console.WriteLine("Habilidades:");

                foreach (var item in pokeInfo.abilities)
                {
                    Console.WriteLine(item["ability"]["name"]);
                }

				var dal = new MascoteDAL(context);

                if (dal.RetornaMascotePorNome(mascote.Nome) == null)
                {
					dal.AdicionarMascote(mascote);

					foreach (var item in pokeInfo.abilities)
					{
						dal = new MascoteDAL(context);
						var ability = new Ability();
						var adoptedPokemon = new PokemonsUsuario();

						ability.Nome = item["ability"]["name"];

						dal.AdicionarHabilidade(ability);

						adoptedPokemon.MascoteId = mascote.Id;
						adoptedPokemon.HabilidadeId = ability.Id;
                        adoptedPokemon.Situcao = "Em espera";

						dal.AdicionarPokemon(adoptedPokemon);
					}
				}

				return mascote;
            }

            return null;
        }
    }
}
