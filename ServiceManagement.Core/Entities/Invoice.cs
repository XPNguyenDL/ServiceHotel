﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Entities;

public class Invoice : IEntity
{
    [Key]
	public int Id { get; set; }
    
    [ForeignKey("Room")]
    public int RoomId { get; set; }

    [Required]
    public double Total { get; set; }

    [Required]
    public bool Paid { get; set; }

    public virtual Room Room { get; set; }
}