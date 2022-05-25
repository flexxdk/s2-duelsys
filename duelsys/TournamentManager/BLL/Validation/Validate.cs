using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    public static class Validate
    {
        public static bool AsString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool AsEnum<T>(string input) where T : Enum
        {
            return Enum.GetNames(typeof(T)).Contains(input);
        }

        public static bool AsDouble(string input)
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

        public static bool AsInt(string input)
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

        public static IEnumerable<string> AsModel(object model)
        {
            List<string> strings = new List<string>();
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, errors))
            {
                foreach(ValidationResult validationResult in errors)
                {
                    strings.Add(validationResult.ErrorMessage ?? "Unspecified error");
                }
            }
            return strings;
        }
    }
}
