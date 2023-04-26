namespace DataValidator;

public class ValidationItem
{
    public ValidationItem(string name, Exception exception, Func<object, bool> validate)
    {
        Validate = validate;
        Name = name;
        Exception = exception;
    }
    public string Name { get; }
    public Exception Exception { get; }
    public Func<object, bool> Validate { get; }
}
