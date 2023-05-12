namespace ServiceManagement.Core.Entities;

public class ServicesInvoice
{
	public int ServiceId { get; set; }

	public int InvoiceId { get; set; }

	public int Quantity { get; set; }

	public int Price { get; set; }

	public Service Service { get; set; }

	public Invoice Invoice { get; set; }
}