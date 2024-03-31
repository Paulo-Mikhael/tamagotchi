using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Model;

namespace Tamagochi.Data.DAL;

public class MascoteDAL
{
	private TamagotchiContext _context;

	public MascoteDAL(TamagotchiContext context)
	{
		_context = context;
	}

	public IEnumerable<Mascote> RetornaMascotes()
	{
		return _context.Mascotes.ToList();
	}

	public Mascote? RetornaMascotePorNome(string nome)
	{
		var mascote = _context.Mascotes.FirstOrDefault(item => item.Nome == nome);

		if (mascote == null)
		{
			return null;
		}

		return mascote;
	}

	public Mascote? RetornaMascotePorId(int id)
	{
		var mascote = _context.Mascotes.FirstOrDefault(item => item.Id == id);

		if (mascote == null)
		{
			return null;
		}

		return mascote;
	}

	public List<int> RetornaHabilidadesPokemon(int id)
	{
		var habilidades = _context.PokemonsUsuarios
			.Where(item => item.MascoteId == id).Select(item => item.HabilidadeId).ToList();

		return habilidades;
	}

	public void AtualizaSituacaoPokemon(int idPoke)
	{
		var mascote = _context.PokemonsUsuarios.Where(item => item.MascoteId == idPoke).ToList();

		foreach (var item in mascote)
		{
			item.Situcao = "Adotado";
			_context.PokemonsUsuarios.Update(item);
			_context.SaveChanges();
		}
	}

	public IEnumerable<PokemonsUsuario> RetornaPokemonsAdotados()
	{
		return _context.PokemonsUsuarios.Where(item => item.Situcao == "Adotado").ToList();
	}

	public PokemonsUsuario? RetornaPokemonUsuario(int id)
	{
		var mascote = _context.PokemonsUsuarios.FirstOrDefault(item => item.MascoteId == id);

		if (mascote == null)
		{
			return null;
		}

		return mascote;
	}

	public void AdicionarPokemon(PokemonsUsuario pokemon)
	{
		_context.PokemonsUsuarios.Add(pokemon);
		_context.SaveChanges();
	}

	public void AdicionarMascote(Mascote mascote)
	{
		_context.Mascotes.Add(mascote);
		_context.SaveChanges();
	}

	public void AdicionarHabilidade(Ability habilidade)
	{
		_context.Habilidades.Add(habilidade);
		_context.SaveChanges();
	}

	public Ability? RetornaHabilidadePorId(int id)
	{
		return _context.Habilidades.FirstOrDefault(item => item.Id == id);
	}
}
