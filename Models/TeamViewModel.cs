using System.ComponentModel.DataAnnotations;

namespace ProjectDbStarter.Models
{
    public class TeamViewModel
    {
        // NOTE: Not sure if this is required or not but we will see later
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team name must be provided")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "Team must be associated with a division")]
        public Division TeamDivision { get; set; }

        [Required(ErrorMessage = "Confirm regisitration status")]
        public bool RegistrationPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public TeamViewModel() { }
    }
}
