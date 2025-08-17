using Applicationn.Interfaces;
using Domain.Entities;

namespace Applicationn.Services

{
	public class PhoneBookServices
	{
		private readonly IPhoneBookRepository _repository;

		public PhoneBookServices(IPhoneBookRepository repository)
		{
			_repository = repository;
		}
		public void AddContact(string name, string phone)
		{
			var contact = new PhoneBookEntry
			{
				Name = name,
				PhoneNumber = phone
			};
			_repository.Add(contact);
		}
		public void UpdateContact(int id, string newName, string newPhone)
		{
			var entry = _repository.GetById(id);
			if (entry != null)
			{
				entry.Name = newName;
				entry.PhoneNumber = newPhone;
				_repository.Update(entry);
			}
		}
		public IEnumerable<PhoneBookEntry> GetContacts()
		{
			return _repository.GetAll();
		}

		public void DeleteContact(int id)
		{
			_repository.Delete(id);
		}
	}
}
