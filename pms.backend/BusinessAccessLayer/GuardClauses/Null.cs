using ExceptionMiddleware;

namespace Ardalis.GuardClauses
{
    public static class PMSNullGuardClause
    {
        public static void Null<T>(this IGuardClause guardClause, T input, string parameterName)
        {
            if (input is null)
                throw new InputIdentifierCanNotBeNullException("input can not be null");
        }
    }
}

