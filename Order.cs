// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public bool Status { get; set; }

    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public List<Payment> Payments { get; set; }
    public List<Product> Products { get; set; }

    public override string ToString()
    {
        return "ID: " + Id + " - " + Date + " - " + "Disponibile: " + Status + " - " + + Amount + " euro";
    }
}