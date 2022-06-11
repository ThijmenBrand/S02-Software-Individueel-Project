using ExceptionMiddleware;

namespace Ardalis.GuardClauses
{
    public static class PMSNullOrEmptyGuardClause
    {
        public static void NullOrEmpty(this IGuardClause guardClause, string input, string parameterName)
        {
            if (string.IsNullOrEmpty(input.Trim()))
                throw new InputIdentifierCanNotBeNullException("input can not be null or empty");
        }
    }
}