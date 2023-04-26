using DataValidator;

namespace DataValidatorTests.TestData;

public abstract class DataConditions : InputData
{
    public static readonly List<ValidationItem> ValidationItems = new()
    {
        BiggerTheZero(nameof(SignUpId)),
        BiggerTheZero(nameof(TotalAllocation)),
        DecimalBiggerTheZero(nameof(Top)),
        DecimalBiggerTheZero(nameof(Bot)),
        EqualZero(nameof(Take))
    };

    private static ValidationItem BiggerTheZero(string name) => new(
        name,
        new ArgumentOutOfRangeException(name),
        value => (int)value > 0
    );

    private static ValidationItem DecimalBiggerTheZero(string name) => new(
        name,
        new ArgumentOutOfRangeException(name),
        value => (decimal)value > 0
    );

    private static ValidationItem EqualZero(string name) => new(
        name,
        new ArgumentOutOfRangeException(name),
        value => (int)value == 0
    );
}