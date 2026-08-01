using Models;
namespace Models
{
    public class NationalReport
    {
        public List<LocationReport> LocationReports { get; set; } = new List<LocationReport>();
        public List<Solicitor> TopSolicitors { get; set; } = new List<Solicitor>();
    }
}