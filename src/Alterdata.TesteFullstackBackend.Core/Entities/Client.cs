namespace Alterdata.TesteFullstackBackend.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email {get; set;}

        public int PhoneNumber { get; set; }

        public bool Active { get; set; }
    }
}
