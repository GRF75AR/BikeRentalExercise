using System;

namespace BikeRental
{
    public static class RentalPrices
    {
        //TODO: Get prices from DB at least once a day
        private static decimal _hourlyPrice = 5;
        private static decimal _dailyPrice = 20;
        private static decimal _weeklyPrice = 60;
            
        public static decimal GetPrice(RentalPeriod period)
        {
            switch (period)
            {
                case RentalPeriod.Hour:
                    return _hourlyPrice;
                case RentalPeriod.Daily:
                    return _dailyPrice;
                case RentalPeriod.Week:
                    return _weeklyPrice;
            }
            throw new NotImplementedException();
        }
    }
}
