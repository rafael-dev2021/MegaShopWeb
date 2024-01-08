using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Cpf { get; set; }
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public string Complement { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Country { get; set; }
    public decimal TotalOrder { get; set; }
    public int TotalItemsOrder { get; set; }
    public DateTime ConfirmedOrder { get; set; }
    public DateTime DispatchedOrder { get; set; }
    public DateTime RequestReceived { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public Payment Payment { get; set; }
}

