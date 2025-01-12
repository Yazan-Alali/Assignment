using Business.Dtos;
using Business.Models;
namespace Business.Interfaces;

public interface IUserService
{
    bool Save(UserRegistrationForm form);
    IEnumerable<User> GetAll();
}