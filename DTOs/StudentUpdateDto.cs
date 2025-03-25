using System.ComponentModel.DataAnnotations;

namespace StudentApi.DTOs
{
    public class StudentUpdateDto
    {
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
