namespace BikeRental
{
    public class Customer
    {
        public Order Order { get; set; }

        public decimal CalculatePay()
        {
            return Order.TotalAmmount;
        }
    }
}
