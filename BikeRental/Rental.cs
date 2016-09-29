using System;

namespace BikeRental
{
    public class Rental
    {
        // Default value for <code>TimePeriods</code>
        private int _timePeriods = 1;

        private RentalPeriod _rentalPeriod;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="bike">The bike to rent.</param>
        /// <param name="period">The time period the rental is intended.</param>
        public Rental(Bike bike, RentalPeriod period)
        {
            RentalPeriod = period;
            PricePerPeriod = RentalPrices.GetPrice(period);
            Bike = bike;
        }

        /// <summary>
        /// Rented <see cref="Bike"/>
        /// </summary>
        public Bike Bike
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="RentalPeriod"/> used to rent bike
        /// </summary>
        public RentalPeriod RentalPeriod
        {
            get
            {
                return _rentalPeriod;
            }
            set
            {
                _rentalPeriod = value;
                PricePerPeriod = RentalPrices.GetPrice(_rentalPeriod);
            }
        }

        /// <summary>
        /// Number of time periods to rent
        /// i.e. when renting 2 hours, value is 2
        /// </summary>
        public int TimePeriods
        {
            get { return _timePeriods; }
            set { _timePeriods = value; }
        }

        /// <summary>
        /// Total Price for the rental
        /// </summary>
        public decimal Price
        {
            get { return PricePerPeriod*TimePeriods; }
        }

        /// <summary>
        /// Price for the <see cref="RentalPeriod"/>
        /// </summary>
        public decimal PricePerPeriod
        {
            get;
            private set;
        }
    }
}
