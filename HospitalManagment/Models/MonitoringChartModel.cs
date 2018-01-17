namespace HospitalManagment.Models
{
    
    public class MonitoringChartModel
    {
        public int MonitoringChartId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string BP { get; set; }
        public int? Pulse { get; set; }
        public string RsNCVS { get; set; }
        public string PA { get; set; }
        public string PV { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
