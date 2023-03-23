using System.ComponentModel.DataAnnotations;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;
public class Room : IEntity
{
	[Key]
	public int Id { get; set; }

	public virtual IList<Service> Services { get; set; }

	public virtual Invoice Invoice { get; set; }
}