using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Feedback : IEntity
{
	public int Id { get; set; }

	public int ServiceId { get; set; }
	
	public string UserName { get; set; }
	
	public string Description { get; set; }
	
	public int Rating { get; set; }
	
	public int MaxRating { get; set; }

	// ======================================================
	// Navigation properties
	// ======================================================

	public Service Service { get; set; }
}