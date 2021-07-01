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
    }
}