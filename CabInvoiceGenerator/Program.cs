using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
            invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, 1, 1);
        }
    }
}
