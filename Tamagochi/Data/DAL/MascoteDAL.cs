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

	public void AdicionarMascote(Mascote mascote)
	{
		_context.Mascotes.Add(mascote);
		_context.SaveChanges();
	}

	public void AdicionarConjunto(Abilities conjunto)
	{
		_context.ConjuntoHabildades.Add(conjunto);
		_context.SaveChanges();
	}

	public void AdicionarHabilidade(Ability habilidade)
	{
		_context.Habilidades.Add(habilidade);
		_context.SaveChanges();
	}
}
