using System.Runtime.Serialization;

namespace IceGestor.CrossCutting.Exceptions;

[Serializable]
public class IceGestorException : SystemException
{
    public IceGestorException(string message) : base(message) { }
    protected IceGestorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
