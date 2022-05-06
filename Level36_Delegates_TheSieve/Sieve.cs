namespace Level36_Delegates_TheSieve;

internal class Sieve
{
    private readonly Func<int, bool> _filterFunc;
    internal Sieve(Func<int, bool> operation) => _filterFunc = operation;
    internal bool IsGood(int number) => _filterFunc(number);
}