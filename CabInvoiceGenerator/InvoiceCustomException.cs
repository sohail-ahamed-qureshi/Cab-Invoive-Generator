using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceCustomException : Exception
    {
        public enum ErrorType
        {
            NO_SUCH_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            PARAMETERS_DOESNT_MEET_REQUIREMENTS

        }

        public ErrorType type;
        public InvoiceCustomException(ErrorType error, string message)
        {
            Console.WriteLine("Error -- "+error +": "+message);
        }
    }
}
