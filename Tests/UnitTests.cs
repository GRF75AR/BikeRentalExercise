using System;
using BikeRental;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        // Test case where customer rents a bike for 1 hour
        public void TestRent1Hour()
        {
            // Arrange
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard), 
                new [] {bike}, 
                RentalPeriod.Hour);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Hour);
            
            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }
        
        [TestMethod]
        // Test case where customer rents a bike for 2 hours
        public void TestRent2Hour()
        {
            // Arrange
            var numberOfPeriods = 2;
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard), 
                new[] { bike }, 
                RentalPeriod.Hour, 
                numberOfPeriods);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Hour) * numberOfPeriods;

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }

        [TestMethod]
        // Test case where customer rents a bike for 1 day
        public void TestRent1Day()
        {
            // Arrange
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard), 
                new[] { bike }, 
                RentalPeriod.Daily);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Daily);
            
            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }
        
        [TestMethod]
        // Test case where customer rents a bike for 3 days
        public void TestRent3Days()
        {
            // Arrange
            var numberOfPeriods = 3;
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard), 
                new[] { bike }, 
                RentalPeriod.Daily, 
                numberOfPeriods);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Daily) * numberOfPeriods;

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }

        [TestMethod]
        // Test case where customer rents a bike for 1 week
        public void TestRent1Week()
        {
            // Arrange
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard), 
                new[] { bike }, 
                RentalPeriod.Week);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Week);

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }


        [TestMethod]
        // Test case where customer rents a bike for 2 weeks
        public void TestRent2Weeks()
        {
            // Arrange
            var numberOfPeriods = 2;
            var bike = new Bike();
            var order = new Order();
            order.AddRentals(
                RentalPackageFactory.Get(RentalPackage.Standard),
                new[] { bike },
                RentalPeriod.Week,
                numberOfPeriods);
            var customer = new Customer { Order = order };

            var expectedPrice = RentalPrices.GetPrice(RentalPeriod.Week) * numberOfPeriods;

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }


        [TestMethod]
        // Test case where customer rents for 2 people, 1 hour each 
        public void TestRentStandard2People()
        {
            // Arrange
            var numberOfPeople = 2;
            var expectedPrice = numberOfPeople * RentalPrices.GetPrice(RentalPeriod.Hour);
            var customer = new Customer();
            var order = new Order();
            order.AddRentals(RentalPackageFactory.Get(RentalPackage.Standard), numberOfPeople, RentalPeriod.Hour);
            customer.Order = order;

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }


        [TestMethod]
        // Test case where customer rents for 4 people, 1 hour each using Promo
        public void TestRentPromo4People()
        {
            // Arrange
            var numberOfPeople = 4;
            var rentalPackage = new FamilyRental();
            var expectedPrice = numberOfPeople * RentalPrices.GetPrice(RentalPeriod.Hour) * (1 - rentalPackage.GetDiscountRate());
            var customer = new Customer();
            var order = new Order();
            order.AddRentals(rentalPackage, numberOfPeople, RentalPeriod.Hour);
            customer.Order = order;

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }

        [TestMethod]
        // Test case where customer rents for 4 people, 1 hour each, using Promo;
        // plus 2 people renting with no promo, 1 day each 
        public void TestRentPromoAndStandard()
        {
            // Arrange
            var numberOfPeople = 4;
            IRentalPackage rentalPackage = new FamilyRental();
            var expectedPrice = numberOfPeople * RentalPrices.GetPrice(RentalPeriod.Hour) * (1 - rentalPackage.GetDiscountRate());
            var customer = new Customer();
            var order = new Order();
            order.AddRentals(rentalPackage, numberOfPeople, RentalPeriod.Hour);
            customer.Order = order;

            //Add a second order, same customer, no promos now, different period
            numberOfPeople = 2;
            rentalPackage = RentalPackageFactory.Get(RentalPackage.Standard);
            expectedPrice += numberOfPeople * RentalPrices.GetPrice(RentalPeriod.Daily);
            order.AddRentals(rentalPackage, numberOfPeople, RentalPeriod.Daily);

            // Act
            var amount = customer.CalculatePay();

            // Assert
            Assert.AreEqual(expectedPrice, amount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        // Test case where customer rents for 1 people, 1 hour each, using Promo
        // Invalid story
        public void TestRentPromoWith1People()
        {
            // Arrange
            var numberOfPeople = 1;
            IRentalPackage rentalPackage = new FamilyRental();
            var customer = new Customer();
            var order = new Order();
            order.AddRentals(rentalPackage, numberOfPeople, RentalPeriod.Hour);
            customer.Order = order;

            // Assert *** ArgumentException ***

        }
    }
}
