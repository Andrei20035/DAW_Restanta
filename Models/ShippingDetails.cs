namespace DAW_Restanta.Models;

public class ShippingDetails
{
    public int ShippingID { get; set; }
    public int OrderID { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public DateTime ShippingDate { get; set; }

    public Order Order { get; set; }
}
