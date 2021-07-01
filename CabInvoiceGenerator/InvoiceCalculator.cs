﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceCalculator
    {
        //variable
        float priceperkm = 0;
        float pricepermin = 0;
        /// <summary>
        /// generate invoice for user's ride
        /// </summary>
        /// <param name="rideType">type of ride</param>
        /// <param name="distance">distance travelled</param>
        /// <param name="time">time take to travel the distance</param>
        public double InvoiceGenerator(RideType.Ride rideType, int distance, int time)
        {
            //ride is premium will have permium prices
            //ride is normal will have normal prices, else throw exception
            try
            {
                if (rideType != RideType.Ride.NORMAL && rideType != RideType.Ride.PREMIUM)
                    throw new Exception();
                if (rideType == RideType.Ride.NORMAL )
                {
                    priceperkm = 10;
                    pricepermin = 1;
                }
                if (rideType == RideType.Ride.PREMIUM)
                {
                    priceperkm = 15;
                    pricepermin = 2;
                }
               //calculate fare price
                double fare = FareCalculator(priceperkm, pricepermin, distance, time);
                Console.WriteLine($"Cab's Invoice \n----------------\n Ride Type:  {rideType} \ndistance:   {distance} km(s), " +
                    $" \ntime:      {time} mins \n------------------\nTotal fare:  {fare} .Rs");
                return fare;
            }
            catch (Exception)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ErrorType.NO_SUCH_TYPE, "No such ridetype exists!!");
            }
        }
        /// <summary>
        /// fare calculator for cab invoice
        /// </summary>
        /// <param name="priceperkm"></param>
        /// <param name="pricepermin"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private double FareCalculator(float priceperkm, float pricepermin, int distance, int time)
        {
            double fare;
            const int MINIMUM_FARE = 20;
            try
            {
                if (distance <= 0)
                    throw new InvoiceCustomException(InvoiceCustomException.ErrorType.INVALID_DISTANCE, "Invalid distance passed");
                if (time <= 0)
                    throw new InvoiceCustomException(InvoiceCustomException.ErrorType.INVALID_TIME, "Invalid time passed");
                fare = distance * priceperkm + time * pricepermin;
                if (fare < MINIMUM_FARE)
                {
                    fare = MINIMUM_FARE;
                    return fare;
                }
                return fare;
            }
            catch (Exception)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ErrorType.PARAMETERS_DOESNT_MEET_REQUIREMENTS, "Distance or time cannot be 0");
            }
        }
    }
}
