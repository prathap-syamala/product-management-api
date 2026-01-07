namespace ProductApi.Models
{
    public class UserFranchise
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
