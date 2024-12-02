using System.ComponentModel.DataAnnotations;

namespace MovieInformationApi.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
