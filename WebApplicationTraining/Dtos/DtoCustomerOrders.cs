namespace WebApplicationTraining.Dtos
{
    public class DtoCustomerOrders
    {

        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public decimal? Freight { get; set; }
    }
}
