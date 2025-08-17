using Domain.Entities;
using Application.Interfaces;

namespace Application.Services
{
	public class PhoneBookService
	{
		private readonly IPhoneBookRepository _repository;
		public PhoneBookService(IPhoneBookRepository repository)
		{
			_repository = repository;
		}
		public async Task AddPhoneBookEntry(string name, string phoneNumber, string email)
		{
			var entry = new PhoneBookEntry { Name = name, PhoneNumber = phoneNumber, Email = email };
			await _repository.AddAsync(entry);
		}
		public async Task<List<PhoneBookEntry>> GetAllBookEntries()
		{
			return await _repository.GetAllAsync();
		}

		public async Task DeletePhoneBookEntry(int id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}
