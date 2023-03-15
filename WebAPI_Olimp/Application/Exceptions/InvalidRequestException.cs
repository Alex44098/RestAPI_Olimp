namespace Application.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() : base($"Request is invalid")
        {

        }
    }
}
