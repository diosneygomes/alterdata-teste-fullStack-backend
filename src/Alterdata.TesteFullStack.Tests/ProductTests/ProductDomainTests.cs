using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Exceptions;

namespace Alterdata.TesteFullStack.Tests.ProductTests
{
    public class ProductDomainTests
    {
        [Fact]
        public void CreateProduct_WhenProductIsCreatedSuccessfully()
        {
            var product = new Product("Test Product", 10.99m, 5);
            
            Assert.Equal("Test Product", product.Name);
            
            Assert.Equal(10.99m, product.Price);
            
            Assert.Equal(5, product.Stock);
        }

        [Fact]
        public void CreateProduct_WithShortName_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Product("AB", 10.99m, 5));
        }

        [Fact]
        public void CreateProduct_WithLongName_ThrowsDomainException()
        {
            var longName = new string('A', 101);

            Assert.Throws<DomainException>(() => new Product(longName, 10.99m, 5));
        }

        [Fact]
        public void CreateProduct_WithZeroPrice_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Product("Test Product", 0m, 5));
        }

        [Fact]
        public void CreateProduct_WithNegativePrice_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Product("Test Product", -10.99m, 5));
        }

        [Fact]
        public void CreateProduct_WithNegativeStock_ThrowsDomainException()
        {
            Assert.Throws<DomainException>(() => new Product("Test Product", 10.99m, -1));
        }

        [Fact]
        public void UpdateProduct_WhenProductIsUpdatedSuccessfully()
        {
            var product = new Product("Test Product - 1", 10.99m, 5);
            
            product.Update("Test Product - 2", 15.99m, 10);
            
            Assert.Equal("Test Product - 2", product.Name);
            
            Assert.Equal(15.99m, product.Price);
            
            Assert.Equal(10, product.Stock);
        }

        [Fact]
        public void UpdateProduct_WithInvalidName_DomainException()
        {
            var product = new Product("Test Product", 10.99m, 5);
            Assert.Throws<DomainException>(() => product.Update("A", 10.99m, 5));
        }

        [Fact]
        public void UpdateProduct_WithZeroPrice_DomainException()
        {
            var product = new Product("Test Product", 10.99m, 5);
            Assert.Throws<DomainException>(() => product.Update("Test Product", 0m, 5));
        }

        [Fact]
        public void UpdateProduct_WithNegativeStock_DomainException()
        {
            var product = new Product("Test Product", 10.99m, 5);
            Assert.Throws<DomainException>(() => product.Update("Test Product", 10.99m, -1));
        }
    }
}
