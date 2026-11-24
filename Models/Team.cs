using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDbStarter.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = "";

        [Column("DivisionId")]
        public Division TeamDivision { get; set; }
        public bool RegistrationPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public Team() { }
    }
}
