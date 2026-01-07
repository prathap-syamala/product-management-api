using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Franchises
{
    public class CreateFranchiseDto
    {
        [Required]
        [MaxLength(150)]
        public string FranchiseName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Total staff must be greater than 0")]
        public int TotalStaff { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [RegularExpression(
            @"^[6-9]\d{9}$",
            ErrorMessage = "Enter a valid 10-digit Indian mobile number"
        )]
        public string Phone { get; set; }
    }
}
