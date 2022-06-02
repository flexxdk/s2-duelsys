namespace BLL.Validation.Exceptions
{
    public class InvalidScoreException : Exception
    {
        public InvalidScoreException(string message)
            : base(message)
        { }
    }
}
