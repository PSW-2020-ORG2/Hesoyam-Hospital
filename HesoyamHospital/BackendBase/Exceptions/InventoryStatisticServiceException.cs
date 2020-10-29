using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class InventoryStatisticServiceException : Exception
    {
        public InventoryStatisticServiceException()
        {

        }

        public InventoryStatisticServiceException(string message) : base(message)
        {

        }

        public InventoryStatisticServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
