using System.ComponentModel.DataAnnotations;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;
public class Room : IEntity
{
	public int Id { get; set; }

	public IList<Invoice> Invoices { get; set; }
}