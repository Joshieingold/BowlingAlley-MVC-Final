namespace ProjectDbStarter.Models
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public Division TeamDivision { get; set; }
        public bool RegistrationPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public TeamViewModel() { }
    }
}
