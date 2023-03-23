using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public enum CarStatus
{
	none
}

public class Car : IEntity
{
	[Key]
	[ForeignKey("Service")]
	public int Id { get; set; }

	[Required]
	public int Type { get; set; }

    [StringLength(50)]
    public string Brand { get; set; }
	
	[Required]
	public DateTime DayRent { get; set; }

	[Required]
	public CarStatus Status { get; set; }

	public virtual Service Service { get; set; }
}