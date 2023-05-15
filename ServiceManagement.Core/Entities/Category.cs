using System.ComponentModel.DataAnnotations;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Category : IEntity
{
	public int Id { get; set; }
	
    public string Name { get; set; }

	public string Description { get; set; }

    public bool Available { get; set; }

    public bool IsDeleted { get; set; }

    public IList<Service> Services { get; set; }
}