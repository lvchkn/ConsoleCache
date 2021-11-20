namespace ConsoleCache.Validators
{
    public static class ValuesValidator
    {
        public static bool Validate(params string[] values)
        {
            foreach (var value in values)
            {
                if(!int.TryParse(value, out var _))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
