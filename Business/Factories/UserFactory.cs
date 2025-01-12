using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create() => new();
    public static User Create(UserRegistrationForm form) => new()
    {
     Id = IdGenerator.Generate(), 
     FirstName = form.FirstName,
     LastName = form.LastName,
     Email = form.Email,
    };
}