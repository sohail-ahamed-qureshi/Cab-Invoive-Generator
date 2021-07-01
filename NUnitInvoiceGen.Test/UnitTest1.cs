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
            double expected = 22;
            int distance = 2;
            int time = 2;
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, distance, time);
            //assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void GivenDistanceEqualsZero_ReturnsException()
        {
            //arrange
            double expected = 0;
            int distance = 0;
            int time = 2;
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, distance, time);
            //assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void GivenTimeEqualsZero_ReturnsException()
        {
            //arrange
            double expected = 0;
            int distance = 2;
            int time = 0;
            //act
            double result = invoiceCalculator.InvoiceGenerator(RideType.Ride.NORMAL, distance, time);
            //assert
            Assert.AreEqual(result, expected);
        }
    }
}