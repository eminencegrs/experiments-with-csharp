namespace CSharp.Experiments.FromDocumentation.ClassesStructsRecords.Methods.LocalFunctions;

// Please, note:
// Depending on their use, local functions can avoid heap allocations
// that are always necessary for lambda expressions.
public static class NthFactorialSample
{
    public static int LocalFunctionFactorial(int n)
    {
        return NthFactorial(n);

        int NthFactorial(int number) => number < 2
            ? 1
            : number * NthFactorial(number - 1);
    }

    public static int LambdaFactorial(int n)
    {
        var nthFactorial = default(Func<int, int>)!;

        nthFactorial = number => number < 2
            ? 1
            : number * nthFactorial(number - 1);

        return nthFactorial(n);
    }
}
