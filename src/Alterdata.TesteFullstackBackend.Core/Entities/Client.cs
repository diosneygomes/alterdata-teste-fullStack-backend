using Alterdata.TesteFullstackBackend.Core.Exceptions;
using System.Text.RegularExpressions;

namespace Alterdata.TesteFullstackBackend.Core.Entities
{
    public sealed class Client
    {
        public Client(
            string name,
            string email,
            string? phoneNumber,
            bool active)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Active = active;

            Validation();
        }

        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Email {get; private set; }

        public string? PhoneNumber { get; private set; }

        public bool Active { get; private set; }

        public void Update(
            string name,
            string email,
            string phoneNumber,
            bool active)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Active = active;

            Validation();
        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrEmpty(Name) || Name.Length < 3 || Name.Length > 100)
            {
                throw new DomainException("Nome é obrigatório e deve ter entre 3 e 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrEmpty(Email) || !Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new DomainException("E-mail é obrigatório e deve ser válido.");
            }
        }
    }
}
