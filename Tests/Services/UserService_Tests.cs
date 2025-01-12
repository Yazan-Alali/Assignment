using System.ComponentModel.DataAnnotations;
using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using Newtonsoft.Json;

namespace Tests.Services;

public class UserService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IUserService _userService;

    public UserService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _userService = new UserService(_fileServiceMock.Object);
    }

    [Fact]
    public void Save_ShouldReturnTrue_AddSaveUserToListAndSaveToFile()
    {
        // arrange
        var userRegistrationForm = new UserRegistrationForm()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
        };

        _fileServiceMock.Setup(x => x.SaveToFile(It.IsAny<string>())).Returns(true);

        // act
        var result = _userService.Save(userRegistrationForm);

        //assert
        Assert.True(result);
        _fileServiceMock.Verify(x => x.SaveToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void GetAll_ShouldReturnListOfUsers()
    {
        // arrange
        List<User> expected = new List<User>
        {
            new User { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" }
        };
        var json = JsonSerializer.Serialize(expected);
        _fileServiceMock.Setup(x => x.GetContentFromFile()).Returns(json);

        // act
        var result = _userService.GetAll();

        // assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected[0].Id, result.First().Id);
        Assert.Equal(expected[0].FirstName, result.First().FirstName);
        Assert.Equal(expected[0].LastName, result.First().LastName);
        Assert.Equal(expected[0].Email, result.First().Email);
    }
}



