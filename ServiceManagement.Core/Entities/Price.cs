using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace ServiceManagement.Core.Entities;

public class Price
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int Rate { get; set; }

	public DateTime? ModifyTime { get; set; }

	[Required]
	public int Quantity { get; set; }

	public double? Discount { get; set; }


	public virtual IList<PriceHistory> PriceHistories { get; set; }
}

public class PriceHistory
{
	[Key]
	public int Id { get; set; }

	[ForeignKey("Service")]
	public int ServiceId { get; set; }

	[ForeignKey("Price")]
	public int PriceId { get; set; }

	public DateTime? ModifyTime { get; set; }

	[StringLength(5000)]
	public string Note { get; set; }

	// ======================================================
	// Navigation properties
	// ======================================================
	
	public virtual Price Price { get; set; }

	[ForeignKey("ServiceId")]
	[InverseProperty("PriceHistories")]
	[Required]
	public virtual Service Service { get; set; }
}