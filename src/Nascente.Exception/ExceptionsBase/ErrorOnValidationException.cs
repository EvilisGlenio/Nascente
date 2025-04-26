namespace Nascente.Exception.ExceptionsBase;

public class ErrorOnValidationException : NascenteException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
