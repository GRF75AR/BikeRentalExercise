using System;

namespace BikeRental
{
    /// <summary>
    /// Rental packages factory
    /// </summary>
    public static class RentalPackageFactory
    {
        public static IRentalPackage Get(RentalPackage package)
        {
            switch (package)
            {
                case RentalPackage.Standard:
                    return new StandardRental();
                case RentalPackage.Family:
                    return new FamilyRental();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}