using System.ComponentModel.DataAnnotations;

namespace MovieInformationApi.DTO
{
    public class ActorDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<MovieDTO> Movies { get; set; }
    }
}
