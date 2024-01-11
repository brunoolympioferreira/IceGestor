using System.Runtime.Serialization;

namespace IceGestor.CrossCutting.Exceptions;

[Serializable]
public class ValidationErrorsException : IceGestorException
{
    public List<string> ErrorMessages { get; set; }
    public ValidationErrorsException(List<string> errorMessages) : base(string.Empty)
    {
        ErrorMessages = errorMessages;
    }
    public ValidationErrorsException(string errorMessage) : base(errorMessage) { }
    protected ValidationErrorsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
