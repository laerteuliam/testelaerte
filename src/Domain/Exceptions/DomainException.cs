using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
       public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
        
        public string BusinessMessage { get; private set; }
    }
}