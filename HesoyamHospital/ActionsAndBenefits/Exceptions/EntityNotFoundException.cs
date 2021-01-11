using System;

namespace ActionsAndBenefits.Exceptions
{
    class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string message) : base(message)
        {

        }

        public EntityNotFoundException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
