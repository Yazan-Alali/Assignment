using Business.Interfaces;
using Business.Services;
using Business;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("users.json"));
serviceCollection.AddSingleton<IUserService, UserService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();

menuDialogs.MainMenu();

