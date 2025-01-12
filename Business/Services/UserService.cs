using System.Text.Json;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly IFileService _fileService;
    private List<User> _users = [];

    public UserService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public IEnumerable<User> GetAll()
    {
        var content = _fileService.GetContentFromFile();
        try
        {
            _users = JsonSerializer.Deserialize<List<User>>(content)!;
        }
        catch
        {
            _users = [];
        }
       return _users;
    }
    
    
    public bool Save(UserRegistrationForm form)
    {
        var user = UserFactory.Create(form);
        _users.Add(user);
        
        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveToFile(json);
        return result;
    }

  
}