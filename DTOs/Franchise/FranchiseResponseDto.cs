using System;

namespace ProductApi.DTOs.Franchises
{
    public class FranchiseResponseDto
    {
        public int Id { get; set; }
        public string FranchiseName { get; set; }
        public string Location { get; set; }
        public int TotalStaff { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public int UserCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleteRequested { get; set; }
        public bool IsDeleted { get; set; }

    }
}
