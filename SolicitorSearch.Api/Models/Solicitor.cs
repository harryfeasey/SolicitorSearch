namespace Models
{    
    public class Solicitor
    {
        public string Name { get; set; } = string.Empty;
        public string Address {get; set;} = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public double? StarRating { get; set; }
        
    }
}