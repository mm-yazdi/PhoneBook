

using Applicationn.Interfaces;
using Domain.Entities;
using Infrastructuree.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructuree.Repositories
{
	public class PhoneBookRepository : IPhoneBookRepository
	{
		private readonly AppDbContext _context;

		public PhoneBookRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(PhoneBookEntry entry)
		{
			_context.phoneBookEntries.Add(entry);
			_context.SaveChanges();
		}

		public PhoneBookEntry GetById(int id)
		{
			return _context.phoneBookEntries.FirstOrDefault(e => e.Id == id);
		}

		public IEnumerable<PhoneBookEntry> GetAll()
		{
			return _context.phoneBookEntries.ToList();
		}

		public void Update(PhoneBookEntry entry)
		{
			_context.phoneBookEntries.Update(entry);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entry = _context.phoneBookEntries.FirstOrDefault(e => e.Id == id);
			if (entry != null)
			{
				_context.phoneBookEntries.Remove(entry);
				_context.SaveChanges();
			}
		}
	}
}
