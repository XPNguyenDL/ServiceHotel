namespace ServiceManagement.Core.DTO;

public class ServicesInvoiceDto
{
	public int ServiceId { get; set; }

	public int InvoiceId { get; set; }

	public int Quantity { get; set; }

	public double Price { get; set; }
}