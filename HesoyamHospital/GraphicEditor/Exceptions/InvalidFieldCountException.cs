using System;

namespace GraphicEditor.Exceptions
{
    public class InvalidFieldCountException : Exception
    {
        public InvalidFieldCountException()
        {

        }

        public InvalidFieldCountException(string message) : base(message)
        {

        }

        public InvalidFieldCountException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
