using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Controller;
using Tamagochi.Data;
using Tamagochi.Data.DAL;
using Tamagochi.Model;

namespace Tamagochi.View
{
    public class WelcomeScreen
    {
        private readonly string userName;

        public WelcomeScreen(string userName)
        {
            this.userName = userName;
        }

        private void Categoria(string text)
        {
            Console.WriteLine($"--------------------------------------------------- {text} ---------------------------------------------------");
        }

        public void MainMenu()
        {
            var main = new MainScreen();
            main.CustomTitle($"Bem vindo {userName}");
            Console.WriteLine("");
            Console.WriteLine("");
            Categoria(" MENU ");
            Console.WriteLine("");
            Console.WriteLine("Pressione a Tecla:");
            Console.WriteLine("");
            Console.WriteLine("1 - Para ver todos os mascotes disponíveis para a adoção");
            Console.WriteLine("2 - Para ver todos os seus mascotes adotados");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("");

            var userChoose = Console.ReadLine();

            while (userChoose != "1" && userChoose != "2" && userChoose != "3")
            {
                Console.WriteLine("Escolha uma Opção");
                userChoose = Console.ReadLine();
            }

            if (userChoose == "1")
            {
                Console.Clear();
                AdoptScreen();
            }
            else if (userChoose == "2")
            {
                Console.Clear();
                UserAdopted();
            }
            else if (userChoose == "3")
            {
                Environment.Exit(0);
            }
        }

        private void AdoptScreen()
        {
            var api = new CallApi();
            var main = new MainScreen();
            main.CustomTitle("Tela de adoção");
            Console.WriteLine("");
            Console.WriteLine("Mascotes para adoção");
            Console.WriteLine("");
            api.PokeNames();
            Console.WriteLine("");
            main.CustomTitle($"Digite o nome do mascote que você deseja adotar ou deseja ver mais detalhes {userName}!");
            Console.WriteLine("");
            var userchoose = Console.ReadLine();
            var mascote = api.RetornaPokemon(userchoose);

            while (mascote == null)
            {
                Console.WriteLine("Mascote não encontrado");
                userchoose = Console.ReadLine();
                mascote = api.RetornaPokemon(userchoose);
            }

            Console.Clear();
            PokeInfo(mascote);
        }

        private void PokeInfo(Mascote mascote)
        {
            var api = new CallApi();
            var main = new MainScreen();
            var context = new TamagotchiContext();
            var dal = new MascoteDAL(context);

            main.CustomTitle($"Informações do {mascote.Nome}");
            Console.WriteLine("");
            Categoria("Características");

            api.RetornaPokemon(mascote.Nome);

            Console.WriteLine("");
            Categoria("Menu");
            Console.WriteLine("Pressione a Tecla:");
            Console.WriteLine("");
            Console.WriteLine($"1 - Adotar {mascote.Nome}");
            Console.WriteLine("2 - Voltar à tela de adoção");

            var userChoose = Console.ReadLine();

            while (userChoose != "1" && userChoose != "2")
            {
                Console.WriteLine("Escolha uma opção");
                userChoose = Console.ReadLine();
            }

            if (userChoose == "1")
            {
                dal.AtualizaSituacaoPokemon(mascote.Id);
                Console.WriteLine("Mascote adotado! Redirecionando para o menu...");
                Thread.Sleep(2000);
                Console.Clear();
                MainMenu();
            }
            else if (userChoose == "2")
            {
                Console.Clear();
                AdoptScreen();
            }
        }

        private void UserAdopted()
        {
            var context = new TamagotchiContext();
            var dal = new MascoteDAL(context);
            var main = new MainScreen();
            var api = new CallApi();

            main.CustomTitle("Mascotes adotados");
            Console.WriteLine("");

            var nomePokeUser = new List<string>();

            var pokeUser = dal.RetornaPokemonsAdotados();
            int idAnterior = 0;
            foreach (var item in pokeUser)
            {
                if (idAnterior != item.MascoteId)
                {
                    var pokemon = dal.RetornaMascotePorId(item.MascoteId);
                    var pokeHabilidades = dal.RetornaHabilidadesPokemon(item.MascoteId);
                    Categoria("--");
                    Console.WriteLine($"Nome: {pokemon.Nome}");
                    nomePokeUser.Add(pokemon.Nome);
                    Console.WriteLine($"Peso: {pokemon.Peso}");
                    Console.WriteLine($"Altura: {pokemon.Altura}");
                    Console.WriteLine("");
                    Console.WriteLine("Habilidades:");

                    foreach (var habilidadeId in pokeHabilidades)
                    {
                        var habilidade = dal.RetornaHabilidadePorId(habilidadeId);
                        Console.WriteLine(habilidade.Nome);
                    }

                    idAnterior = item.MascoteId;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Digite 1 para voltar ao menu");
            Console.WriteLine("Digite o nome de um mascote adotado para exibir os seus status");

            var userChoose = Console.ReadLine();
            var pokemonPego = "";

            foreach (var item in nomePokeUser)
            {
                if (userChoose.ToString() == item)
                {
                    pokemonPego = item;
                }
            }

            while (userChoose != "1" && pokemonPego == "")
            {
                Console.WriteLine("Pokemon não encontrado/adotado");
                userChoose = Console.ReadLine();

                foreach (var item in nomePokeUser)
                {
                    if (userChoose.ToString() == item)
                    {
                        pokemonPego = item;
                    }
                }
            }

            if (userChoose == "1")
            {
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.Clear();
                PokeStatus(pokemonPego);
            }
        }

        public void PokeStatus(string pokemon)
        {
            var random = new Random();
            var temperamentoRandom = random.Next(0, pokemonTemperamentos.Count);
            var temperamento = pokemonTemperamentos[temperamentoRandom];

			var main = new MainScreen();
            var api = new CallApi();
            main.CustomTitle($"Status do mascote {pokemon.ToUpper()}");
            Console.WriteLine("");
            Console.WriteLine($"Saúde: {random.Next(0, 101)}");
            Console.WriteLine("");
            Console.WriteLine($"Temperamento agora: {temperamento}");
            Categoria("Você deseja");
            Console.WriteLine($"1 - Fazer carinho em {pokemon}");
			Console.WriteLine($"2 - Brincar com {pokemon}");
			Console.WriteLine($"3 - Alimentar {pokemon}");
			Console.WriteLine("4 - Sair");

            var userChoose = Console.ReadLine();

            while (userChoose != "1" && userChoose != "2" && userChoose != "3" && userChoose != "4")
            {
                Console.WriteLine("");
                Console.WriteLine("Escolha uma opção");
				userChoose = Console.ReadLine();
			}

            if (userChoose == "2")
            {
                switch (temperamento)
                {
                    case "Enfurecido":
                        Console.WriteLine("");
                        Console.WriteLine($"{pokemon.ToUpper()} não quer brincar e está mais enfurecido!");
                        break;
					case "Agitado":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} adorou a brincadeira e está mais agitado");
						break;
					case "Confortável":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} brinca um pouco mas logo se encontra deitado novamente");
						break;
					case "Cansado":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} nem se mexeu...");
						break;
					case "Feliz":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} gostou de brincar com o seu dono");
						break;
					case "Triste":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} não estar para brincadeira e se vira...");
						break;
					case "Raiva":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} brinca com você mas o machuca sem querer");
						break;
					case "Medo":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} foge de você...");
						break;
                    default:
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} está dormindo");
                        break;
				}
            }

			if (userChoose == "1")
			{
				switch (temperamento)
				{
					case "Enfurecido":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} morde sua mão quando você tenta se aproximar");
						break;
					case "Agitado":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} não para de se mover para aproveitar o carinho");
						break;
					case "Confortável":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} se aconchega em você e aproveita o cafuné");
						break;
					case "Cansado":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} nem se mexeu...");
						break;
					case "Feliz":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} aproveita o cafuné");
						break;
					case "Triste":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} nem se mexeu... mas parece estar gostando");
						break;
					case "Raiva":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} aproveita o cafuné, mas lembra que está com raiva e morde sua mão");
						break;
					case "Medo":
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} vê você se aproximando com a mão aberta e foge");
						break;
					default:
						Console.WriteLine("");
						Console.WriteLine($"{pokemon.ToUpper()} está dormindo");
						break;
				}
			}
		}

        private List<string> pokemonTemperamentos = new List<string>
        {
            "Enfurecido",
            "Agitado",
            "Confortável",
            "Cansado",
            "Feliz",
            "Triste",
            "Raiva",
            "Medo"
        };
    }
}
