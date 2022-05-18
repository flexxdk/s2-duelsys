namespace BLL.Validation
{
    public static class Validator
    {
        public static bool ValidateString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool ValidateEnum<T>(string input) where T : Enum
        {
            return Enum.GetNames(typeof(T)).Contains(input);
        }

        public static bool ValidateDouble(string input)
        {
            try
            {
                Convert.ToDouble(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateInt(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
