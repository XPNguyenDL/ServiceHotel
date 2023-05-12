using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Service : IEntity
{
	public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Description { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public bool Available { get; set; }

    public int CategoryId { get; set; }

    // ======================================================
    // Navigation properties
    // ======================================================

	public Category Category { get; set; }

    public IList<Feedback> Feedback { get; set; }

    public Car Car { get; set; }

    public IList<PriceHistory> PriceHistories { get; set; }

    public IList<ServicesInvoice> ServicesInvoices { get; set; }
}