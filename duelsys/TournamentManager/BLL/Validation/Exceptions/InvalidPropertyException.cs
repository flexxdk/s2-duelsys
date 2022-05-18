namespace BLL.Validation.Exceptions
{
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() : base("The given property does not exist.") { }
    }
}
