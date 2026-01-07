using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FranchiseName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [Range(1, 100)]
        public int TotalStaff { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }   // string, NOT int

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserFranchise> UserFranchises { get; set; }
    }
}
