using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double Distance { get; set; }
        public double Time { get; set; }
        public Ride(double distance, double time)
        {
            Distance = distance;
            Time = time;
        }
    }
}
