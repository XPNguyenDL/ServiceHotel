using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Feedback : IEntity
{
	[Key]
	[Column(Order = 1)]
	[ForeignKey("Service")]
	public int Id { get; set; }

	[StringLength(500)]
	public string UserName { get; set; }

	[StringLength(5000)]
	public string Description { get; set; }

	[Required]
	public int Rating { get; set; }

	[Required]
	public int MaxRating { get; set; }

	// ======================================================
	// Navigation properties
	// ======================================================

	public virtual Service Service { get; set; }

}