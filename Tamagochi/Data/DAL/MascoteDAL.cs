using System;
using System.Collections.Generic;
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

	public string? RetornaMascotePorId(int id)
	{
		var mascote = _context.Mascotes.FirstOrDefault(item => item.Id == id);

		if (mascote == null)
		{
			return null;
		}

		return mascote.Nome;
	}

	public void AdicionarPokemon(PokemonsUsuario pokemon)
	{
		_context.PokemonsUsuarios.Add(pokemon);
		_context.SaveChanges();
	}

	public IEnumerable<PokemonsUsuario?> RetornaPokemonsUsuario()
	{
		return _context.PokemonsUsuarios.ToList();
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
}
