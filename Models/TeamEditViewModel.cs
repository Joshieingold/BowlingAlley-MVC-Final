namespace ProjectDbStarter.Models
{
    public class TeamEditViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public Division TeamDivision { get; set; }
        public bool RegistrationPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public TeamEditViewModel() { }
    }
}
