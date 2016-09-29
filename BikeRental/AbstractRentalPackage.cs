namespace BikeRental
{
    /// <summary>
    /// Abstract rental package
    /// </summary>
    public class AbstractRentalPackage : IRentalPackage
    {
        private decimal DiscountPercentage = 0;

        public Rental GetRental(RentalPeriod period)
        {
            return new Rental(new Bike(), period);
        }

        public Rental GetRental(RentalPeriod period, Bike bike)
        {
            return new Rental(bike, period);
        }

        public virtual decimal GetDiscountRate()
        {
            return DiscountPercentage;
        }

        public virtual int GetMinimumRentals()
        {
            return 1;
        }
    }
}
