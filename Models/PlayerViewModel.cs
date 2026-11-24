namespace ProjectDbStarter.Models
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public PlayerViewModel() { }
    }
}
