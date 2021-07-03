using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<int, Ride[]> dt;
        public RideRepository()
        {
            //initializing some userId's
            Ride[] ride = new Ride[2];
            ride[0] = new Ride { Distance = 12, Time = 1 };
            ride[1] = new Ride { Distance = 12, Time = 1 };
            Ride[] ride1 = new Ride[2];
            ride1[0] = new Ride { Distance = 22, Time = 1 };
            ride1[1] = new Ride { Distance = 22, Time = 1 };
            dt = new Dictionary<int, Ride[]>();
            dt.Add(1, ride);
            dt.Add(2, ride1);
        }

        /// <summary>
        /// perform invoice calculation of particular userId
        /// </summary>
        /// <param name="userId">userId of a person</param>
        public double GetInvoice(int userId)
        {
            double average = 0, totalfare = 0;
            InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
            if (dt.ContainsKey(userId))
            {
                Console.WriteLine("UserId: " + userId);
                Ride[] rides = dt[userId];
                totalfare = invoiceCalculator.InvoiceGenerator(rides, out average);
                Console.WriteLine($"totalfare : {totalfare} \n Average fare: {average}");
            }
            return totalfare;
        }
    }
}
