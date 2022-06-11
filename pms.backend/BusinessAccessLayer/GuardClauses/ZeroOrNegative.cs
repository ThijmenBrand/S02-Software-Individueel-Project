using ExceptionMiddleware;

namespace Ardalis.GuardClauses
{
    public static class PMSNegativeOrZeroGuardClause
    {
        public static void NegativeOrZero(this IGuardClause guardClause, int input, string parameterName)
        {
            if (input <= 0)
                throw new InputIdentifierCanNotBeZeroException("input has to be greater than zero");
        }
    }
}
