public interface IErrorResponseBuilder
{
    ErrorResponse FromException(Exception ex);
}