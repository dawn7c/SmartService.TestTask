namespace SmartService.Application.Validation
{
    public class Validator
    {
        public ValidationResult CheckForNull(object input)
        {
            if (input == null)
            {
                return new ValidationResult(false, "Cannot be zero");
            }

            return new ValidationResult(true, "Validation completed successfully");
        }
    }      
}

