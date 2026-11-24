using System.ComponentModel.DataAnnotations;

// All validation comes from the DB's field limitations
namespace ProjectDbStarter.Models
{
    public class PlayerViewModel
    {
        // NOTE: Not sure if this is required or not but we will see later
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Player must be associated with a team.")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Player must have a name.")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Player provide city location.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Player provide a valid Email Address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Player provide a valid Phone Number.")]
        [Phone]
        public string Phone { get; set; }

        public PlayerViewModel() { }
    }
}
