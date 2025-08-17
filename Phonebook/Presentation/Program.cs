using Applicationn.Interfaces;
using Applicationn.Services;
using Infrastructuree;
using Infrastructuree.Data;
using Infrastructuree.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
var host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		// اتصال به دیتابیس
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer("Server=.;Database=PhonebookDb;Trusted_Connection=True;TrustServerCertificate=True;"));

		// رجیستر Repository
		services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

		// رجیستر Service
		services.AddScoped<PhoneBookServices>();
	})
	.ConfigureLogging(logging =>
	{
		logging.ClearProviders();
	})
	.Build();
	
// گرفتن سرویس
var service = host.Services.GetRequiredService<PhoneBookServices>();
// منو
while (true)
{
	Console.WriteLine("1- Add Contact");
	Console.WriteLine("2- Update Contact");
	Console.WriteLine("3- List Contacts");
	Console.WriteLine("4- Delete Contact");
	Console.WriteLine("5- Exit");
	Console.Write("Choose an option: ");

	var choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			Console.Write("Enter Name: ");
			var name = Console.ReadLine();
			Console.Write("Enter Phone: ");
			var phone = Console.ReadLine();
			service.AddContact(name, phone);
			Console.WriteLine("✅ Contact added.\n");
			break;

		case "2":
			Console.Write("Enter ID to update: ");
			int idToUpdate = int.Parse(Console.ReadLine()!);
			Console.Write("Enter new Name: ");
			var newName = Console.ReadLine();
			Console.Write("Enter new Phone: ");
			var newPhone = Console.ReadLine();
			service.UpdateContact(idToUpdate, newName, newPhone);
			Console.WriteLine("✅ Contact updated.\n");
			break;

		case "3":
			var contacts = service.GetContacts();
			foreach (var c in contacts)
			{
				Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Phone: {c.PhoneNumber}");
			}
			Console.WriteLine();
			break;

		case "4":
			Console.Write("Enter ID to delete: ");
			int idToDelete = int.Parse(Console.ReadLine()!);
			service.DeleteContact(idToDelete);
			Console.WriteLine("✅ Contact deleted.\n");
			break;

		case "5":
			return;
	}
}