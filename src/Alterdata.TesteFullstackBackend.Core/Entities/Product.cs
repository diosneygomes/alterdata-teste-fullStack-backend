using Alterdata.TesteFullstackBackend.Core.Exceptions;

namespace Alterdata.TesteFullstackBackend.Core.Entities
{
    public sealed class Product
    {
        public Product(
            string name,
            decimal price,
            int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;

            Validation();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
        
        public decimal Price { get; private set; }

        public int Stock {  get; private set; }

        public void Update(
            string name,
            decimal price,
            int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;

            Validation();
        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrEmpty(Name) || Name.Length < 3 || Name.Length > 100)
            {
                throw new DomainException("Nome é obrigatório e deve ter entre 3 e 100 caracteres.");
            }

            if (Price <= 0)
            {
                throw new DomainException("O valor do produto tem que ser maior que zero");
            }

            if (Stock < 0)
            {
                throw new DomainException("A quantidade em estoque tem que ser maior ou igual a zero");
            }
        }
    }
}
