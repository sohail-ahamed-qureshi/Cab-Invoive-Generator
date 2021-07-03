using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitInvoiceGen.Test
{
    public class Tests
    {
        InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
        [Test]
        public void GivenDistanceAndTime_ReturnsTotalFare()
        {
            //arrange
            double expected = 20;
            double distance = 5;
            double time = 2;
            Ride ride = new Ride(distance, time)
            {
                Distance = distance,
                Time = time
            };
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.PREMIUM, ride);
            //assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void GivenDistanceEqualsZero_ReturnsException()
        {
            //arrange
            double expected = 0;
            double distance = 0;
            double time = 2;
            Ride ride = new Ride(distance, time)
            {
                Distance = distance,
                Time = time
            };
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, ride);
            //assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void GivenTimeEqualsZero_ReturnsException()
        {
            //arrange
            double expected = 0;
            double distance = 2;
            double time = 0;
            Ride ride = new Ride(distance, time)
            {
                Distance = distance,
                Time = time
            };
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, ride);
            //assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void GivenMultipleValue_ReturnsAggregateTotal() 
        {
            //arrange
            Ride[] ride = new Ride[3];
            double distance0 = 12;
            double time0 = 1;
            double distance1 = 22;
            double time1 = 2;
            double average = 0;
            ride[0] = new Ride(distance0, time0) { Distance = distance0, Time = time0 };
            ride[1] = new Ride(distance1, time1) {   Distance = distance1,  Time = time1 };
            ride[2] = new Ride{  Distance = 11, Time = 10  };
            double expected = 463.00;
            //act
            InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
            double result = invoiceCalculator.InvoiceGenerator(ride, out average);
            //assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenMultipleValue_ReturnsAverageTotal()
        {
            //arrange
            Ride[] ride = new Ride[3];
            double distance0 = 12;
            double time0 = 1;
            double distance1 = 22;
            double time1 = 2;
            double average = 0;
            ride[0] = new Ride(distance0, time0) { Distance = distance0, Time = time0 };
            ride[1] = new Ride(distance1, time1) { Distance = distance1, Time = time1 };
            ride[2] = new Ride { Distance = 11, Time = 10 };
            double expected = 463.00;
            double expectedAverage = 154;
            //act
            InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
            double result = invoiceCalculator.InvoiceGenerator(ride, out average);
            //assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expectedAverage, average);
        }
    }
}