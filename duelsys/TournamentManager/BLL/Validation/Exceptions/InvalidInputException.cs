namespace BLL.Validation.Exceptions
{
    public class InvalidInputException : Exception
    {
        private string Default { get; } = "Could not add object because of invalid input information. Please check all input fields and dropdown box to ensure that all fields are filled out.";

        private string FirstName { get; }

        public InvalidInputException(string message) 
            : base(message)
        { }

        public InvalidInputException(string message, Exception inner)
            : base(message, inner)
        { }

        public InvalidInputException(string message, string firstName)
            : base(message)
        { 
            FirstName = firstName;
        }
    }
}
