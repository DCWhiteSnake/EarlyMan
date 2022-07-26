namespace EarlyManTests
{
    public class UserControllerTests
    {
        [InlineData("daamazink@gmail.com", "123456")]
        [InlineData("tony.okeke@ymail.com", "123456")]
        [Theory]
        public async void Login_Button_Logs_User_In(string email, string password)
        {
          
        }
    }
}