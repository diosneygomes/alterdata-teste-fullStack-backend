namespace Alterdata.TesteFullStackBackend.Application.Exceptions
{
    public class ClientNullException : Exception
    {
        public ClientNullException()
        { }

        public ClientNullException(string message) : base(message)
        { }

        public ClientNullException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
