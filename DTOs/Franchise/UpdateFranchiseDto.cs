using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Franchise
{
    public class UpdateFranchiseDto
    {
        [Required]
        [MaxLength(150)]
        public string FranchiseName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [Range(1, 10000)]
        public int TotalStaff { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
    }
}
