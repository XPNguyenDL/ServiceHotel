using System.ComponentModel.DataAnnotations;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Category : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
    [StringLength(50)]
    public string Name { get; set; }

	[StringLength(500)]
	public string Description { get; set; }
}