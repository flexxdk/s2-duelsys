namespace BLL.Validation.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Could not add object because of invalid input information. Please check all input fields and dropdown box to ensure that all fields are filled out.")
        { }
    }
}
