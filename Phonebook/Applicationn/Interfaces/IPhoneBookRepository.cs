
using Domain.Entities;

namespace Applicationn.Interfaces
{
	public interface IPhoneBookRepository
	{
		void Add(PhoneBookEntry entry);
		PhoneBookEntry GetById(int id);
		IEnumerable<PhoneBookEntry> GetAll();
		void Update(PhoneBookEntry entry);
		void Delete(int id);
	}
}
