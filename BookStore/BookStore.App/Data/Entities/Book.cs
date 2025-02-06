﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BookStore.App.Data.Emities;

public class Book
{
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Title { get; set; }
    [Required]
    [StringLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string Isbn { get; set; }
    [Required]
    [StringLength(50)] 
    public string Category { get; set; }
    public string Publisher { get; set; }
    [Required]

    public DateTime PublisheAt { get; set; }


    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }

}
