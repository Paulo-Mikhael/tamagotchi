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

            main.CustomTitle($"Informações do {mascote.Nome}");
            Console.WriteLine("");
            Categoria("Características");
            Console.WriteLine($"Nome: {mascote.Nome}");
            Console.WriteLine($"Peso: {mascote.Peso}");
            Console.WriteLine($"Altura: {mascote.Altura}");
            Console.WriteLine($"\r\nHabilidades:");

            foreach (var item in mascote.Habilidades)
            {
                foreach (var habilidade in item.ConjuntoHabilidades)
                {
                    Console.WriteLine(habilidade.Nome);
                }
            }

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
				var dal = new MascoteDAL(context);
                dal.AdicionarMascote(mascote);

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
            main.CustomTitle("Mascotes adotados");
            Console.WriteLine("");

            var mascotes = dal.RetornaMascotes();

            foreach (var item in mascotes)
            {
                var nome = item.Nome;
                var peso = item.Peso;
                var altura = item.Altura;
                var habilidades = item.Habilidades;

                Categoria(nome);
                Console.WriteLine($"Nome: {nome}");
                Console.WriteLine($"Peso: {peso}");
                Console.WriteLine($"Altura: {altura}");
                Console.WriteLine($"\r\nHabilidades:");

                /*foreach (var conjunto in habilidades)
                {
                    foreach (var habilidade in conjunto.ConjuntoHabilidades)
                    {
                        Console.WriteLine(habilidade.Nome);
                    }
                }*/
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Digite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
    }
}
