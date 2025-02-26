using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Exceptions;

namespace Alterdata.TesteFullStack.Tests.ClientTests
{
    public class ClientDomainTests
    {
        [Fact]
        public void CreateClient_WhenClientIsCreatedSuccessfully()
        {
            var client = new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", true);
            
            Assert.Equal("Test Client - 1", client.Name);
            Assert.Equal("testeclient@alterdata.com.br", client.Email);
        }

        [Fact]
        public void CreateClient_WithShortName_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Client("AB", "testeclient@alterdata.com.br", "(99) 99999-9999", true));
        }

        [Fact]
        public void CreateClient_WithLongName_ThrowsDomainException()
        {
            var longName = new string('A', 101);

            Assert.Throws<DomainException>(() => new Client(longName, "testeclient@alterdata.com.br", "(99) 99999-9999", true));
        }

        [Fact]
        public void CreateClient_WithInvalidEmail_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Client("Test Client - 1", "invalid-email", "(99) 99999-9999", true));
        }

        [Fact]
        public void CreateClient_WithoutPhone_ShouldBeValid()
        {
            var client = new Client("Test Client - 1", "testeclient@alterdata.com.br", null, true);
            Assert.Null(client.PhoneNumber);
        }

        [Fact]
        public void UpdateClient_WhenClientIsUpdatedSuccessfully()
        {
            var client = new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", false);

            client.Update("Test Client - 2", "emailupdated@alterdata.com.br", "(88) 88888-8888", true);

            Assert.Equal("Test Client - 2", client.Name);

            Assert.Equal("emailupdated@alterdata.com.br", client.Email);

            Assert.Equal("(88) 88888-8888", client.PhoneNumber);
            
            Assert.True(client.Active);
        }

        [Fact]
        public void UpdateClient_WithInvalidEmail_DomainException()
        {
            var client = new Client("Test Client", "testeclient@alterdata.com.br", "(99) 99999-9999", false);

            Assert.Throws<DomainException>(() => client.Update("Test Client", "invalid-email", "(99) 99999-9999", false));
        }
    }
}
