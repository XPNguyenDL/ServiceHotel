using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace ServiceManagement.Core.Entities;

public class Price
{
	public int Id { get; set; }
	
	public float ServicePrice { get; set; }

	public double Discount { get; set; }

	public IList<PriceHistory> PriceHistories { get; set; }
}

public class PriceHistory
{
	public int Id { get; set; }

	public int ServiceId { get; set; }

	public int PriceId { get; set; }

	public DateTime ModifyTime { get; set; }

	public string Note { get; set; }

	// ======================================================
	// Navigation properties
	// ======================================================
	
	public Price Price { get; set; }
	
	public Service Service { get; set; }
}