using AdministrationSystem.Data;

namespace UnitTests.DataTests
{
    public class FirebaseConnectionTests
    {
        [Fact]
        public void client_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();

            // act
            var client = firebaseConnection.client();

            // assert
            Assert.NotNull(client);
        }
    }
}
