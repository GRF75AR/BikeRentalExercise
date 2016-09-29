namespace BikeRental
{
    public interface IRentalPackage
    {
        /// <summary>
        /// Gets a <see cref="Rental"/> for the rental period
        /// </summary>
        /// <param name="period">Rental period</param>
        /// <returns>Rental for a given rental period</returns>
        Rental GetRental(RentalPeriod period);

        /// <summary>
        /// Gets a <see cref="Rental"/> for the rental period
        /// </summary>
        /// <param name="period">Rental period</param>
        /// /// <param name="bike">Bike to rent</param>
        /// <returns>Rental for a given rental period</returns>
        Rental GetRental(RentalPeriod period, Bike bike);

        /// <summary>
        /// Get Discount Percentage.
        /// Ranges from 0 (no discount) to 1 (free)
        /// </summary>
        /// <returns>Discount rate, from 0 (no discount) to 1 (100% discount)</returns>
        decimal GetDiscountRate();

        /// <summary>
        /// Get minimum rentals to proceed with the package
        /// </summary>
        /// <returns></returns>
        int GetMinimumRentals();
    }
}
