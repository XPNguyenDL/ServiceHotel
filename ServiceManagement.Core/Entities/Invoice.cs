using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Invoice : IEntity
{
	public int Id { get; set; }

	public int RoomId { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public string Note { get; set; }
    
    public double Total { get; set; }
    
    public bool Paid { get; set; }

    // ======================================================
    // Navigation properties
    // ======================================================

    public IList<ServicesInvoice> ServicesInvoices { get; set; }

	public Room Room { get; set; }
}