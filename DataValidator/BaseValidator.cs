namespace DataValidator;

public class BaseValidator
{
    public BaseValidator(Type type, object obj, IEnumerable<ValidationItem> validationItems)
    {
        foreach (var item in from item in validationItems
                             let property = type.GetProperty(item.Name)
                             where property != null
                             let value = property.GetValue(obj)
                             where !item.Validate(value)
                             select item)
        {
            throw item.Exception;
        }
    }
}
