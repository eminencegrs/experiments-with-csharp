using CSharp.Experiments.FromDocumentation.ClassesStructsRecords.Methods.LocalFunctions;
using Shouldly;
using Xunit;

namespace CSharp.Experiments.FromDocumentation.Tests.ClassesStructsRecords.Methods.LocalFunctions;

public class NthFactorialSampleTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void GivenNumber_WhenLocalFunctionFactorial_ThenResultAsExpected(
        int n, int expectedResult)
    {
        NthFactorialSample.LocalFunctionFactorial(n).ShouldBe(expectedResult);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GivenNumber_WhenLambdaFactorial_ThenResultAsExpected(
        int n, int expectedResult)
    {
        NthFactorialSample.LambdaFactorial(n).ShouldBe(expectedResult);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return [0, 1];
        yield return [1, 1];
        yield return [2, 2];
        yield return [3, 6];
        yield return [4, 24];
        yield return [5, 120];
    }
}
