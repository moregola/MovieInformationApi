namespace MovieInformationApi.DTO
{
    public class ActorDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }
}
