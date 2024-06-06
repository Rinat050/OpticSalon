namespace OpticSalon.Domain.Models.Report
{
    public class ClientReportItem
    {
        public int ClientId { get; set; }
        public string Client { get; set; } = "";
        public int OrderCount { get; set; }
        public bool IsNew { get; set; }
    }
}
