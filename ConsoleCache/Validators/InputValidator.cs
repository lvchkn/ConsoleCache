using System.Linq;

namespace ConsoleCache.Validators
{
    public static class InputValidator
    {
        public static (bool isInputValid, string commandName, string[] values) TryValidateInput(string[] input)
        {
            if (input is null || input.Length == 0 || input.Length > 3)
            {
                return (false, null, null);
            }

            var values = input.Skip(1).ToArray();

            if (input.Length == 1 && values.Length == 0)
            {
                return (true, input[0], null);
            }

            if (!ValuesValidator.Validate(values))
            {
                return (false, input[0], null);
            }

            return (true, input[0], values);
        }
    }
}
