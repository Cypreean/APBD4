using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        // Arrange
        string email = "invalidEmail";
        string firstName = "John";
        string lastName = "Doe";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(false, result);
    }

    [Fact]

    public void AddUser_Should_Return_False_When_FirstName_Is_Empty()
    {
        // Arrange
        string email = "correctemail@wp.pl";
        string firstName = "";
        string lastName = "Doe";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        var userService = new UserService();

        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Normal_Client_With_No_Credit_Limit()
    {
        // Arrange
        string email = "kowalski@wp.pl";
        string firstName = "John";
        string lastName = "Kowalski";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        var userService = new UserService();

        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);

    }

    [Fact]
    public void Add_User_Should_Return_False_When_User_Is_Under_21()
    {
        // Arrange
        string email = "wdwWp@wp.pl";
        string firstName = "John";
        string lastName = "Doe";
        DateTime dateOfBirth = DateTime.Parse("2020-03-21");
        int clientId = 1;
        var userService = new UserService();

        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]

    public void AddUser_Should_Return_True_When_User_Is_Added()
    {
        // Arrange
        string email = "dsa@wp.pl";
        string firstName = "John";
        string lastName = "Doe";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        //Assert
        Assert.Equal(true, result);
        
    }

    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Empty()
    {
        // Arrange
        string email = "dw@wp.pl";
        string firstName = "John";
        string lastName = "";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        var userService = new UserService();

        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client ()
    {
        // Arrange
        string email = "w@wp.pl";
        string firstName = "John";
        string lastName = "Doe";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 3;
        var userService = new UserService();

        //Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(true, result);
    }
}