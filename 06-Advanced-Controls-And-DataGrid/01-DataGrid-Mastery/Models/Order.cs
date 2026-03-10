namespace DataGridMastery.Models;
public class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public bool IsShipped { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
}
