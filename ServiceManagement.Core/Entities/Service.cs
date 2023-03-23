using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Service : IEntity
{
    [Key]
	public int Id { get; set; }

    [StringLength(512)]
    public string Name { get; set; }

    [StringLength(5000)]
    public string Description { get; set; }

    [Required]
    public string Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public bool Active { get; set; }

    [Required]
    public bool Avaliable { get; set; }


    // ======================================================
    // Navigation properties
    // ======================================================

	public virtual Category Category { get; set; }

    public virtual IList<Feedback> Feedbacks { get; set; }

    public virtual Car Car { get; set; }

    public virtual IList<Room> Rooms { get; set; }

}