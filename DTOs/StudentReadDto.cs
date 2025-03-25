using System.ComponentModel.DataAnnotations;

namespace StudentApi.DTOs
{
    public class StudentReadDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        [EmailAddress]
        public required string Email { get; set; }

        public StudentProfileReadDto? Profile { get; set; }
    }
}

