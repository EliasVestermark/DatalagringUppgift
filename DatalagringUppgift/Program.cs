using DatalagringUppgift.Interfaces.IServices;
using DatalagringUppgift.Repositories;
using DatalagringUppgift.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\elias\source\repos\DatalagringUppgift\DatalagringUppgift\Data\ProductCatalog.mdf;Integrated Security=True;Connect Timeout=30";

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton(new ClientRepository(connectionString));
    services.AddSingleton(new LocationRepository(connectionString));
    services.AddSingleton(new BookingRepository(connectionString));
    services.AddSingleton<IBookingService, BookingService>();
    services.AddSingleton<IMenuService, MenuService>();
}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<IMenuService>();

menuService.ShowMainMenu();