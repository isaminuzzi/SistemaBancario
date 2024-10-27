using System.ComponentModel.DataAnnotations;

namespace Application.Common;

public static class ValidationExtensions
{
    public static void CheckIfModelIsValid<T>(this T obj)
    {
        ValidationContext validationContext = new ValidationContext((object)obj);
        List<ValidationResult> source = new List<ValidationResult>();
        if (!Validator.TryValidateObject((object)obj, validationContext, (ICollection<ValidationResult>)source, true))
            throw new Exception(source.FirstOrDefault<ValidationResult>().ErrorMessage);
    }
}