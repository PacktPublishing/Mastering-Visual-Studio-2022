
using Sandbox.Core;

namespace Sandbox.UserTests;

public class UserTest
{
    [Fact]
    public void ValidateMail_NewUser_ReturnsTrue()
    {
        // Arrange
        var user = new User();

        // Act
        bool result = user.ValidateMail("john@example.com");

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("invalidemail")] 
    [InlineData("invalidemail@")]
    [InlineData("invalidemail@example")]
    [InlineData("invalidemail@example.")]
    [InlineData("invalidemail@.com")]
    public void Register_InvalidEmail_ReturnsFalse(string email)
    {
        // Arrange
        var user = new User();

        // Act
        bool result = user.ValidateMail(email);

        // Assert
        Assert.False(result);
    }
}
































//[Theory]
//[InlineData("invalidemail")] // Missing '@' symbol
//[InlineData("invalidemail@")] // Missing domain
//[InlineData("invalidemail@example")] // Missing top-level domain
//[InlineData("invalidemail@example.")] // Domain with only dot
//[InlineData("invalidemail@.com")] // Domain without characters
//public void Register_InvalidEmail_ReturnsFalse(string email)
//{
//    // Arrange
//    var userManager = new UserManager();

//    // Act
//    bool result = userManager.Register(email, "StrongPassword123");

//    // Assert
//    Assert.False(result);
//}


//}
