namespace BikeRental
{
    public class FamilyRental : AbstractRentalPackage
    {
        //TODO: Get values from DB
            
        public override decimal GetDiscountRate()
        {
            return .3m;
        }

        public override int GetMinimumRentals()
        {
            return 3;
        }
    }
}
