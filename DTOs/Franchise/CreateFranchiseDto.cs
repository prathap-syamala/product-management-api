using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Franchises
{
    public class CreateFranchiseDto
    {
        public string FranchiseName { get; set; }

        public string Location { get; set; }

        public int TotalStaff { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
