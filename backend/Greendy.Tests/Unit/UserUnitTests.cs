/*using FluentAssertions;
namespace Greendy.Tests.Unit
{
    public class UserUnitTests
    {
        [Theory]
        [InlineData("validmail@google.com", false)]
        [InlineData("invalidmail.google.com", true)]
        public void TestEmailValidation(string email, bool shouldThrow)
        {
            string firstName = "John";
            string lastName = "Dou";
            string userName = "johndou";
            string password = "somebamboo";

            Action act = () => new User(firstName, lastName, userName, password, email,
                    null);
			if (shouldThrow) 
			{
				(act).Should().Throw<InvalidEmailException>();
			}
			else {
				(act).Should().NotThrow<InvalidEmailException>();
			}
        }

		[Theory]
		[InlineData("Qwer1234!")]
		[InlineData("SomeHardP@ss21204WWord!")]	
		public void PasswordSaltAndHashStaySame(string password)
		{
			string firstName = "John";
			string lastName = "Dou";
			string userName = "johndou";
			string email = "johndou@gmail.com";
			User user = new(firstName, lastName, userName, password, email,null);
			var isPasswordSame = user.CheckPassword(password);
			isPasswordSame.Should().Be(true, "Password validation data" 
					+ "should'nt change with time");
			
		}
    }
}

*/