using DataValidatorTests.TestData;
using Xunit;

namespace DataValidatorTests;

public class DataValidatorTest
{
    private readonly InputData _inputData = new()
    {
        SignUpId = 100,
        TotalAllocation = 10000,
        Top = 0.9m,
        Bot = 0.1m,
        MinAmount = 250,
        WinnersRatio = 0.1m,
        Take = 0
    };

    [Fact]
    public void AllDataIsValid()
    {
        var validationItems = DataConditions.ValidationItems;
        _ = new BaseValidator(typeof(InputData), _inputData, validationItems);

        Assert.True(true);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void SomeDataIsWrongReturnException(int value, string propName)
    {
        switch (propName)
        {
            case "Take":
                _inputData.Take = value;
                break;
            case "SignUpId":
                _inputData.SignUpId = value;
                break;
            case "TotalAllocation":
                _inputData.TotalAllocation = value;
                break;
        }

        var errorMessage = $"Specified argument was out of the range of valid values. (Parameter '{propName}')";
        
        var validationItems = DataConditions.ValidationItems;
        var validator = Assert.Throws<ArgumentOutOfRangeException>(() => new BaseValidator(typeof(InputData), _inputData, validationItems));
        
        Assert.Equal(errorMessage, validator.Message);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 1, "Take"};
        yield return new object[] { 0, "SignUpId"};
        yield return new object[] { 0, "TotalAllocation"};
    }
}