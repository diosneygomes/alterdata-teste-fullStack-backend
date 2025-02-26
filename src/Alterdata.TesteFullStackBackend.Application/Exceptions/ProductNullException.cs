namespace Alterdata.TesteFullStackBackend.Application.Exceptions
{
    public class ProductNullException : Exception
    {
        public ProductNullException()
        { }

        public ProductNullException(string message) : base(message)
        { }

        public ProductNullException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
