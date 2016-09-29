using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental
{
    /// <summary>
    /// Represents a customer's order
    /// </summary>
    public class Order
    {
        public ICollection<Rental> Rentals { get; private set; }
        public DateTime StartDate { get; set; }
        public decimal TotalAmmount { get; private set; }

        public Order()
        {
            Rentals = new List<Rental>();
            TotalAmmount = 0;
        }

        /// <summary>
        /// Add a rental to the order, with a specific bike
        /// </summary>
        /// <param name="rentalPackage">IRentalPackage</param>
        /// <param name="bikes">Bikes to rent</param>
        /// <param name="period">Rent period</param>
        /// /// <param name="timePeriods">Optional quantity of periods</param>
        public void AddRentals(IRentalPackage rentalPackage, IEnumerable<Bike> bikes, RentalPeriod period, int timePeriods = 1)
        {
            // Check validity of params
            CheckMinimumRentals(rentalPackage.GetMinimumRentals(), bikes.Count());
            foreach (var bike in bikes)
            {
                var rental = rentalPackage.GetRental(period, bike);
                Rentals.Add(rental);
                rental.TimePeriods = timePeriods;
                TotalAmmount += rental.Price * (1 - rentalPackage.GetDiscountRate());
            }
        }

        /// <summary>
        /// Add a collection of n rentals to the order, without choosing a specific bike
        /// </summary>
        /// <param name="rentalPackage">IRentalPackage</param>
        /// <param name="quantity">Quantity of rentals to add</param>
        /// <param name="period">Rent period</param>
        public void AddRentals(IRentalPackage rentalPackage, int quantity, RentalPeriod period)
        {
            // Check validity of params
            CheckMinimumRentals(rentalPackage.GetMinimumRentals(), quantity);
            for (int i=0; i<quantity; i++)
            {
                var rental = rentalPackage.GetRental(period);
                Rentals.Add(rental);
                TotalAmmount += rental.Price*(1 - rentalPackage.GetDiscountRate());
            }
        }

        private void CheckMinimumRentals(int getMinimumRentals, int quantity)
        {
            if(quantity<getMinimumRentals)
                throw new ArgumentException("Not enough rentals for this package");
        }
    }
}
