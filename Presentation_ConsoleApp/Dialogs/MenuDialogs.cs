using Business.Factories;
using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogs;

public class MenuDialogs(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-- MENU OPTION --");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine();
            Console.Write("Select Option:");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    AddUserOption();
                    break;
                case "2":
                    ViewAllUsersOption();
                    break;
            }
        }
    }

    public void AddUserOption()
    {
        var form = UserFactory.Create();
        
        Console.Clear();
        Console.WriteLine("-- NEW USER --");
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;
        
        var result = _userService.Save(form);
        if (result)
            Console.Write("User Was created successfully.");
        else
            Console.Write("User was not created.");

        Console.ReadKey();
    }

    public void ViewAllUsersOption()
    {
        Console.Clear();
        Console.WriteLine("-- VIEW ALL USERS --");
        
        var users = _userService.GetAll();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>");
        }
        Console.ReadKey();
    }
}