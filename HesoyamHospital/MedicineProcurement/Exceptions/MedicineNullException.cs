using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Exceptions
{
    public class MedicineNullException : Exception
    {
        public MedicineNullException()
        {

        }

        public MedicineNullException(string message) : base(message)
        {

        }

        public MedicineNullException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
