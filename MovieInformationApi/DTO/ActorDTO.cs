using System.ComponentModel.DataAnnotations;

namespace MovieInformationApi.DTO
{
    public class ActorDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
