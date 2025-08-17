
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;
public class PhoneBookRepository:IPhoneBookRepository
{
	private readonly AppDbContext _context;
	public PhoneBookRepository(AppDbContext context)
	{
		_context = context;
	}
	public async Task AddAsync(PhoneBookEntry entry)
	{
		await _context.phoneBookEntries.AddAsync(entry);
		await _context.SaveChangesAsync();
	}
	public async Task<List<PhoneBookEntry>> GetAllAsync()
	{
		return await _context.phoneBookEntries.ToListAsync();
	}
	public async Task<PhoneBookEntry> GetByIdAsync(int id)
	{
		return await _context.phoneBookEntries.FindAsync(id);
	}
	public async Task UpdateAsync(PhoneBookEntry entry)
	{
		_context.phoneBookEntries.Update(entry);
		await _context.SaveChangesAsync();
	}
	public async Task DeleteAsync(int id)
	{
		var entry = await _context.phoneBookEntries.FindAsync(id);
		if (entry != null)
		{
			_context.phoneBookEntries.Remove(entry);
			await _context.SaveChangesAsync();
		}
	}
}
