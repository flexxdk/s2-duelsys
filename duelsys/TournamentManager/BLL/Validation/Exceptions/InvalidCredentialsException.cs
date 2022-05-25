namespace BLL.Validation.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid login credentials.") 
        { }
    }
}
