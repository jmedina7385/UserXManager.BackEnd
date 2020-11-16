namespace UserXManager.Validators
{
    public static class PermissionValidator
    {
        public static PermissionValidatorResult ValidateIsNotEmpty(this PermissionValidatorResult validator,
            string input)
        {
            if (validator == null) validator = new PermissionValidatorResult();
            else if (!validator.IsValid) return validator;


            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                validator.Message = "Input Is Empty";
                validator.IsValid = false;
            }
            else
            {
                validator.Message = "Input Is Not Empty";
                validator.IsValid = true;
            }

            return validator;
        }

        public static PermissionValidatorResult WithRequiredCharacters(this PermissionValidatorResult validator,
            string input, int charsNumber)
        {
            if (validator == null) validator = new PermissionValidatorResult();
            else if (!validator.IsValid) return validator;

            if (input.Length >= charsNumber)
            {
                validator.Message = "Input Has Valid Characters";
                validator.IsValid = true;
            }
            else
            {
                validator.Message = $"Input Has Not Valid Characters at least {charsNumber}";
                validator.IsValid = false;
            }

            return validator;
        }
    }
}