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
	public int Id { get; set; }
	
	public string Type { get; set; }

    public string Brand { get; set; }
	
	public int DayRent { get; set; }

	public CarStatus Status { get; set; }

	public Service Service { get; set; }
}